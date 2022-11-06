using Application.Configuration;
using Application.Errors;
using Application.Models;
using Application.Models.Enum;
using Application.Services.Interfaces;

namespace Application.Services;

public class RelatorioDistribuicaoService : IRelatorioDistribuicaoService
{
    private readonly ApiContext _connection;
    private readonly IFuncionarioService _funcionario;
    private readonly IConfiguracaoCalculoService _configuracaoCalculo;
    private readonly IPesoService _peso;

    public RelatorioDistribuicaoService(ApiContext connection,
                                        IFuncionarioService funcionario,
                                        IConfiguracaoCalculoService configuracaoCalculo,
                                        IPesoService peso)
    {
        _connection = connection;
        _funcionario = funcionario;
        _configuracaoCalculo = configuracaoCalculo;
        _peso = peso;
    }
    public async Task<RelatorioDistribuicao> GetLast()
    {
        var result = _connection.RelatorioDistribuicao.OrderByDescending(e => e.CreationDate).FirstOrDefault();

        if (result == null)
            throw new NotFoundException();

        return await Task.FromResult<RelatorioDistribuicao>(result);
    }
    public async Task<IEnumerable<RelatorioDistribuicao>> GetAll()
    {
        var result = _connection.RelatorioDistribuicao
            .OrderByDescending(e => e.CreationDate)
            .ToList();

        return await Task.FromResult(result == null ? new List<RelatorioDistribuicao>() : result);
    }

    public async Task<RelatorioDistribuicao> GetById(int id)
    {
        var result = _connection.RelatorioDistribuicao.Where(e => e.Id == id).FirstOrDefault();

        if (result == null)
            throw new NotFoundException();

        return await Task.FromResult<RelatorioDistribuicao>(result);
    }

    public async Task<RelatorioDistribuicao> Generate()
    {
        var configuracaoCalculo = await _configuracaoCalculo.Get();

        var entity = new RelatorioDistribuicao()
        {
            Pesos = await _peso.GetAll(),
            TotalDisponibilizado = configuracaoCalculo.ValorTotalDisponibilizado,
            SalarioMinimo = configuracaoCalculo.SalarioMinimo,
            Funcionarios = new List<RelatorioDistribuicaoFuncionario>()
        };

        var relatorioFuncionarios = await ProcessarFuncionarios(entity.Pesos, entity.SalarioMinimo);
        entity.Funcionarios = relatorioFuncionarios;
        entity.TotalDistribuido = relatorioFuncionarios.Sum(f => f.ValorTotal);
        entity.SaldoDisponibilizadoDistribuido = entity.TotalDisponibilizado - entity.TotalDistribuido;

        entity.UpdatedDate = DateTime.Now;
        entity.CreationDate = DateTime.Now;
        entity.Ativo = true;

        _connection.RelatorioDistribuicao.Add(entity);
        await _connection.SaveChangesAsync();
        return entity;
    }

    private async Task<IEnumerable<RelatorioDistribuicaoFuncionario>> ProcessarFuncionarios(IEnumerable<Peso> pesos, double salarioMinimo)
    {
        List<Funcionario> funcionarios = (await _funcionario.GetAll()).ToList();
        var relatorioFuncionarios = new List<RelatorioDistribuicaoFuncionario>();

        foreach (var funcionario in funcionarios)
        {
            RelatorioDistribuicaoFuncionario relatorioFuncionario = new RelatorioDistribuicaoFuncionario()
            {
                Matricula = funcionario.Matricula,
                Nome = funcionario.Nome,
                AreaAtuacao = funcionario.AreaAtuacao,
                Cargo = funcionario.Cargo,
                SalarioBruto = funcionario.SalarioBruto,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Ativo = true
            };

            double valorCalculado = this.RelatorioFormula(pesos, relatorioFuncionario, salarioMinimo);

            relatorioFuncionario.ValorDisponibilizado = valorCalculado;
            relatorioFuncionario.ValorTotal = valorCalculado + funcionario.SalarioBruto;

            relatorioFuncionarios.Add(relatorioFuncionario);
        }

        return await Task.FromResult(relatorioFuncionarios);
    }

    /// <summary>
    /// Realiza o cálculo do relatório usando a formula:
    /// ((((Salário Bruto * Peso A) + (Salário Bruto * Peso B)) / (Salário Bruto * Peso C)) * 12 meses
    /// </summary>
    /// <param name="pesos"></param>
    /// <param name="relatorioFuncionario"></param>
    /// <param name="salarioMinimo"></param>
    /// <returns></returns>
    private double RelatorioFormula(IEnumerable<Peso> pesos,
                                    RelatorioDistribuicaoFuncionario relatorioFuncionario,
                                    double salarioMinimo)
    {
        int meses = 12;
        double result, sb = relatorioFuncionario.SalarioBruto;

        double pesoPorAreaDeAtuacao = _peso.GetPesoPorAreaDeAtuacao(relatorioFuncionario.AreaAtuacao);
        double pesoPorTempoDeAdmissao = _peso.GetPesoPorTempoDeAdmissao(relatorioFuncionario.DataAdmissao);
        double pesoPorFaixaSalarial = _peso.GetPesoPorFaixaSalarial(relatorioFuncionario.SalarioBruto, salarioMinimo);

        result =
            ((sb * pesoPorAreaDeAtuacao) + (sb * pesoPorAreaDeAtuacao)
            ) / (sb * pesoPorFaixaSalarial);
        result = result * meses;

        return result;
    }
}
