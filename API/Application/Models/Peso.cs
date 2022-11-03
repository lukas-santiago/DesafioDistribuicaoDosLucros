using Application.Models.Enum;

namespace Application.Models
{
    public class Peso : BaseModel
    {
        public TipoPeso TipoPeso { get; set; }
        public int Valor { get; set; }
        public string Nome { get; set; } = String.Empty;
        public ICollection<Funcionario> funcionarios { get; set; }
    }
}