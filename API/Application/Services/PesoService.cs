using Application.Configuration;
using Application.Errors;
using Application.Models;
using Application.Models.Enum;
using Application.Services.Interfaces;

namespace Application.Services;

public class PesoService : IPesoService
{
    private readonly ApiContext _connection;
    private readonly IConfiguracaoCalculoService _configuracaoCalculo;

    public PesoService(ApiContext connection, IConfiguracaoCalculoService configuracaoCalculo)
    {
        _configuracaoCalculo = configuracaoCalculo;
        _connection = connection;
    }
    public async Task<IEnumerable<Peso>> GetAll()
    {
        return await Task.FromResult(_connection.Peso.Where(e => e.Ativo == true).ToList());
    }

    public async Task<IEnumerable<Peso>> GetByType(TipoPeso tipoPeso)
    {
        var result = _connection.Peso
            .Where(e => e.Ativo == true && e.TipoPeso == tipoPeso)
            .ToList();
        return await Task.FromResult(result);
    }
    public int GetPesoPorAreaDeAtuacao(long AreaAtuacao)
    {
        var result = _connection.Peso.Single(p => p.TipoPeso == TipoPeso.PesoPorAreaDeAtuacao
            && p.Id == AreaAtuacao && p.Ativo == true).Valor;

        return result;
    }
    public int GetPesoPorFaixaSalarial(double salarioBruto, double salarioMinimo)
    {
        var pesos = _connection.Peso
            .Where(e => e.Ativo == true && e.TipoPeso == TipoPeso.PesoPorFaixaSalarial)
            .OrderBy(p => p.Valor)
            .ToList();

        foreach (Peso peso in pesos)
        {
            if (peso.ValorMinimo == 0
                && salarioBruto <= (peso.ValorMaximo * salarioMinimo))
                return peso.Valor;
            if (peso.ValorMaximo == 0
                && salarioBruto > (peso.ValorMinimo * salarioMinimo))
                return peso.Valor;
            if (salarioBruto >= (peso.ValorMinimo * salarioMinimo)
                && salarioBruto <= (peso.ValorMaximo * salarioMinimo))
                return peso.Valor;
        }

        throw new NotFoundException();
    }
    public int GetPesoPorTempoDeAdmissao(DateTime dataAdmissao)
    {
        int anosDeContribuicao = CalculateYearsOfDiferenceFromNow(dataAdmissao);

        var pesos = _connection.Peso
            .Where(e => e.Ativo == true && e.TipoPeso == TipoPeso.PesoPorTempoDeAdmissao)
            .OrderBy(p => p.Valor)
            .ToList();

        foreach (Peso peso in pesos)
        {
            if (peso.ValorMinimo == 0 && anosDeContribuicao <= peso.ValorMaximo)
                return peso.Valor;

            if (peso.ValorMaximo == 0 && anosDeContribuicao > peso.ValorMinimo)
                return peso.Valor;

            if (anosDeContribuicao >= peso.ValorMinimo && anosDeContribuicao <= peso.ValorMaximo)
                return peso.Valor;
        }

        throw new NotFoundException();
    }
    private int CalculateYearsOfDiferenceFromNow(DateTime date)
    {
        DateTime zeroDay = new DateTime(1, 1, 1);
        TimeSpan span = date.Subtract(DateTime.Now);
        return (zeroDay + span.Negate()).Year - 1;
    }
}
