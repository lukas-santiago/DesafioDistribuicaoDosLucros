using Application.Models.Enum;

namespace Application.Models;
public class Funcionario : BaseModel
{
    public string Matricula { get; set; } = String.Empty;
    public string Nome { get; set; } = String.Empty;
    public long AreaAtuacao { get; set; }
    public TipoCargo Cargo { get; set; }
    public double SalarioBruto { get; set; }
    public DateTime DataAdmissao { get; set; }
    public bool Ativo { get; set; } = true;
}