namespace Application.Models;

public class RelatorioDistribuicao : BaseModel
{
    public double TotalDisponibilizado { get; set; }
    public double TotalDistribuido { get; set; }
    public double SalarioMinimo { get; set; }
    public double SaldoDisponibilizadoDistribuido { get; set; }
    public ICollection<RelatorioDistribuicaoFuncionario> RelatorioDistribuicaoFuncionario { get; set; }
    public int TotalFuncionarios { get => RelatorioDistribuicaoFuncionario == null ? 0 : RelatorioDistribuicaoFuncionario.Count(); }
    public ICollection<RelatorioDistribuicaoPeso> RelatorioDistribuicaoPeso { get; set; }
}
