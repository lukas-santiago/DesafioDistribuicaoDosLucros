namespace Application.Models;

public class RelatorioDistribuicao : BaseModel
{
    public double TotalDisponibilizado { get; set; }
    public double TotalDistribuido { get; set; }
    public double SalarioMinimo { get; set; }
    public double SaldoDisponibilizadoDistribuido { get; set; }
    public IEnumerable<RelatorioDistribuicaoFuncionario> Funcionarios { get; set; }
    public int TotalFuncionarios { get => Funcionarios.Count(); }
    public IEnumerable<Peso> Pesos { get; set; }
}
