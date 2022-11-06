using Application.Models;
using Application.Models.Enum;

namespace Application.Services.Interfaces;

public interface IRelatorioDistribuicaoService
{
    public Task<IEnumerable<RelatorioDistribuicao>> GetAll();
    public Task<RelatorioDistribuicao> GetById(int id);
    public Task<RelatorioDistribuicao> GetLast();
    public Task<RelatorioDistribuicao> Generate();
}