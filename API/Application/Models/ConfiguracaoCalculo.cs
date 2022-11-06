namespace Application.Models;

public class ConfiguracaoCalculo : BaseModel
{
    public double ValorTotalDisponibilizado { get; set; }
    public double SalarioMinimo { get; set; } = 1000;
}
