using Application.Configuration;
using Application.Errors;
using Application.Models;
using Application.Services.Interfaces;

namespace Application.Services;

public class ConfiguracaoCalculoService : IConfiguracaoCalculoService
{
    private readonly ApiContext _connection;

    public ConfiguracaoCalculoService(ApiContext connection)
    {
        _connection = connection;
    }
    public async Task<IEnumerable<ConfiguracaoCalculo>> GetAll()
    {
        var entity = _connection.ConfiguracaoCalculo.OrderByDescending(f => f.CreationDate).ToList();
        return entity;
    }
    public async Task<ConfiguracaoCalculo> Get()
    {
        var entity = _connection.ConfiguracaoCalculo.OrderByDescending(f => f.CreationDate).First();

        if (entity == null)
            throw new NotFoundException();

        return entity;
    }
    public async Task Edit(ConfiguracaoCalculo value)
    {
        var oldEntity = _connection.ConfiguracaoCalculo.FirstOrDefault(e => e.Ativo == true);

        if (oldEntity == null)
            throw new NotFoundException();

        if (oldEntity.ValorTotalDisponibilizado == value.ValorTotalDisponibilizado)
            throw new EqualException();

        oldEntity.Ativo = false;
        _connection.ConfiguracaoCalculo.Update(oldEntity);

        value.CreationDate = DateTime.Now;
        value.UpdatedDate = DateTime.Now;

        _connection.ConfiguracaoCalculo.Add(value);
        await _connection.SaveChangesAsync();
    }
}
