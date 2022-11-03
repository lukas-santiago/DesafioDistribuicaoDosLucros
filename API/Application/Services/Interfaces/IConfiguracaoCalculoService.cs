using Application.Models;

namespace Application.Services.Interfaces;

public interface IConfiguracaoCalculoService
{
    public Task<ConfiguracaoCalculo> Get();
    public Task<bool> Edit(ConfiguracaoCalculo value);
}
