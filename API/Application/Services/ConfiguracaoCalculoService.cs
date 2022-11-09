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
        return await Task.FromResult(entity);
    }
    public async Task<ConfiguracaoCalculo> Get()
    {
        var entity = _connection.ConfiguracaoCalculo.OrderByDescending(f => f.Id).First();

        if (entity == null)
            throw new NotFoundException();

        return await Task.FromResult(entity);
    }
    public async Task Edit(ConfiguracaoCalculo value)
    {
        var oldEntity = _connection.ConfiguracaoCalculo.FirstOrDefault(e => e.Ativo == true);

        if (oldEntity == null)
            throw new NotFoundException("Configuração não encontrada");

        if (oldEntity.ValorTotalDisponibilizado == value.ValorTotalDisponibilizado && oldEntity.SalarioMinimo == value.SalarioMinimo)
            throw new EqualException("Objeto retornou igual ao armazenado");

        if (value.ValorTotalDisponibilizado == 0 && value.SalarioMinimo == 0)
            throw new CannotBeZeroException("Não pode haver propriedades com valor zero");

        oldEntity.Ativo = false;
        _connection.ConfiguracaoCalculo.Update(oldEntity);

        value.CreationDate = DateTime.Now;
        value.UpdatedDate = DateTime.Now;
        value.Ativo = true;

        _connection.ConfiguracaoCalculo.Add(value);
        await _connection.SaveChangesAsync();
    }
}
