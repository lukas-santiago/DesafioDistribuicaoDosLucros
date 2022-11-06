using Application.Models;

namespace Application.Services.Interfaces;

public interface IConfiguracaoCalculoService
{
    public Task<IEnumerable<ConfiguracaoCalculo>> GetAll();
    public Task<ConfiguracaoCalculo> Get();
    public Task Edit(ConfiguracaoCalculo value);
}
