namespace Application.Models;

public class RelatorioDistribuicao
{
    public double TotalDisponibilizado { get; set; }
    public double TotalDistribuido { get; set; }
    public double RelacaoDisponibilizadoPorDistribuido { get; set; }
    public IEnumerable<RelatorioDistribuicaoFuncionario> funcionarios { get; set; }
    public int TotalFuncionarios { get => funcionarios.Count(); }
    public IEnumerable<Peso> pesos { get; set; }
    public DateTime CreationDate { get; set; }
}
