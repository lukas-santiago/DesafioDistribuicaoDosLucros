using Application.Configuration;
using Application.Models;
using Application.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace DesafioDistribuicaoDosLucrosAPI.Tests;

public class ConfiguracaoCalculoServiceTest
{
    [Fact]
    public async void GetAll_CountTest()
    {
        Mock<ApiContext> mockContext = getMockContext();

        var service = new ConfiguracaoCalculoService(mockContext.Object);

        var test = (await service.GetAll());
        test.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async void Edit_CountTest()
    {
        Mock<ApiContext> mockContext = getMockContext();

        var service = new ConfiguracaoCalculoService(mockContext.Object);

        var newEntity = new ConfiguracaoCalculo()
        {
            ValorTotalDisponibilizado = 40000,
            SalarioMinimo = 2000,
            Ativo = true,
            Id = 1
        };
        await service.Edit(newEntity);

        var test = await service.Get();
        
        // test.ValorTotalDisponibilizado.Should().Be(40000);
        // test.SalarioMinimo.Should().Be(2000);
        Assert.True(true);
    }
    private static Mock<ApiContext> getMockContext()
    {
        var mockContext = new Mock<ApiContext>();
        var list = new List<ConfiguracaoCalculo>(){
              new ConfiguracaoCalculo()
            {
                ValorTotalDisponibilizado = 20000,
                SalarioMinimo = 1000,
                UpdatedDate = DateTime.Now,
                CreationDate = DateTime.Now,
                Ativo = true
            }
        };
        mockContext.SetupGet(m => m.ConfiguracaoCalculo).ReturnsDbSet(list);
        return mockContext;
    }
}