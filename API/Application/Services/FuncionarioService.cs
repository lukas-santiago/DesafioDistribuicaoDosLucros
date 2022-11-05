using Application.Configuration;
using Application.Errors;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;
public class FuncionarioService : IFuncionarioService
{
    private readonly ApiContext _connection;

    public FuncionarioService(ApiContext connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Funcionario>> GetAll()
    {
        return await _connection.Funcionario.ToListAsync();
    }
    public async Task<Funcionario> Get(long id)
    {
        var entity = await _connection.Funcionario.FindAsync(id);

        if (entity == null)
            throw new NotFoundException();

        return entity;
    }

    public async Task<Funcionario> Add(Funcionario value)
    {
        if (value.Id != 0)
            throw new AlreadyExistsException();

        await _connection.Funcionario.AddAsync(value);
        await _connection.SaveChangesAsync();

        return value;
    }
    public async Task<Funcionario> Edit(Funcionario value)
    {
        var entity = await _connection.Funcionario.FindAsync(value.Id);

        if (entity == null)
            throw new NotFoundException();

        entity.Matricula = value.Matricula;
        entity.Nome = value.Nome;
        entity.AreaAtuacao = value.AreaAtuacao;
        entity.Cargo = value.Cargo;
        entity.SalarioBruto = value.SalarioBruto;
        entity.DataAdmissao = value.DataAdmissao;

        entity.UpdatedDate = DateTime.Now;

        _connection.Funcionario.Update(entity);
        await _connection.SaveChangesAsync();
        
        return entity;
    }

    public async Task Delete(long id)
    {
        var entity = await _connection.Funcionario.FindAsync(id);

        if (entity == null)
            throw new NotFoundException();

        _connection.Funcionario.Remove(entity);
        await _connection.SaveChangesAsync();
    }
}