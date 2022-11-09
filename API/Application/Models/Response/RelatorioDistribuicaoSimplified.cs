namespace Application.Models.Response;
public class RelatorioDistribuicaoSimplified
{
    public double TotalDisponibilizado { get; set; }
    public double TotalDistribuido { get; set; }
    public double SalarioMinimo { get; set; }
    public double SaldoDisponibilizadoDistribuido { get; set; }
    public int TotalFuncionarios { get; set; }
    public long Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}