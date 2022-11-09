using Application.Models;
using Application.Models.Enum;
using Application.Models.Response;

namespace Application.Services.Interfaces;

public interface IRelatorioDistribuicaoService
{
    public Task<IEnumerable<RelatorioDistribuicaoSimplified>> GetAll();
    public Task<RelatorioDistribuicao> GetById(int id);
    public Task<RelatorioDistribuicao> GetLast();
    public Task<RelatorioDistribuicao> Generate();
}