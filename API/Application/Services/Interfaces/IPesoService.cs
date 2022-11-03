using Application.Models;
using Application.Models.Enum;

namespace Application.Services.Interfaces;

public interface IPesoService
{
    public Task<IEnumerable<Peso>> GetAll();
    public Task<IEnumerable<Peso>> GetByType(TipoPeso tipoPeso);
}
