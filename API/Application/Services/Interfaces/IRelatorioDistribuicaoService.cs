using Application.Models;
using Application.Models.Enum;

namespace Application.Services.Interfaces;

public interface IRelatorioDistribuicaoService
{
    public Task<RelatorioDistribuicao> GetAll();
    public Task<RelatorioDistribuicao> GetLast();
    public Task<RelatorioDistribuicao> Calculate();
}