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
}