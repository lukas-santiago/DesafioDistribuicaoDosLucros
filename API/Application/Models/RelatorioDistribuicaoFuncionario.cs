namespace Application.Models;

public class RelatorioDistribuicaoFuncionario
{
    public string Matricula { get; set; } = String.Empty;
    public string AreaAtuacao { get; set; } = String.Empty;
    public string Cargo { get; set; } = String.Empty;
    public double SalarioBruto { get; set; }
    public double ValorDisponibilizado { get; set; }
    public double ValorTotal { get; set; }
    public DateTime CreationDate { get; set; }
}