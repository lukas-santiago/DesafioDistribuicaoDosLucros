using Application.Models.Enum;

namespace Application.Models
{
    public class Peso : BaseModel
    {
        public TipoPeso TipoPeso { get; set; }
        public int Valor { get; set; }
        public string Nome { get; set; } = String.Empty;

        public double ValorMaximo { get; set; } = 0;
        public double ValorMinimo { get; set; } = 0;
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}