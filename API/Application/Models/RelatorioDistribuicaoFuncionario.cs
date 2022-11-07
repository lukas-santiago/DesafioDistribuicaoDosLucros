using Application.Models.Enum;

namespace Application.Models;

public class RelatorioDistribuicaoFuncionario : BaseModel
{
    public string Matricula { get; set; } = String.Empty;
    public string Nome { get; set; } = String.Empty;
    public long AreaAtuacao { get; set; }
    public DateTime DataAdmissao { get; set; }
    public TipoCargo Cargo { get; set; }
    public double SalarioBruto { get; set; }
    public double ValorDisponibilizado { get; set; }
    public double ValorTotal { get; set; }
    public long RelatorioDistribuicaoId { get; set; }
    public RelatorioDistribuicao RelatorioDistribuicao { get; set; }

}

public class RelatorioDistribuicaoPeso : Peso
{
    public RelatorioDistribuicaoPeso()
    {
    }
    public RelatorioDistribuicaoPeso(Peso peso)
    {
        TipoPeso = peso.TipoPeso;
        Valor = peso.Valor;
        Nome = peso.Nome;
        ValorMaximo = peso.ValorMaximo;
        ValorMinimo = peso.ValorMinimo;
        Funcionarios = peso.Funcionarios;

        CreationDate = peso.CreationDate;
        UpdatedDate = peso.UpdatedDate;
        Ativo = peso.Ativo;
    }

    public long RelatorioDistribuicaoId { get; set; }
    public RelatorioDistribuicao? RelatorioDistribuicao { get; set; }

}