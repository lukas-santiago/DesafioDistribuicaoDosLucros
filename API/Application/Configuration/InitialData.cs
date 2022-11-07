using Application.Models;
using Application.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Application.Configuration;
public class InitialDataGenerator
{
    public InitialDataGenerator(ApiContext context)
    {
        // using (var context = new ApiContext(serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
        // {
        SetUpPesos(context);
        SetUpFuncionarios(context);
        SetUpConfiguracaoCalculo(context);
        // }
    }

    private void SetUpConfiguracaoCalculo(ApiContext context)
    {
        if (context.ConfiguracaoCalculo.Any()) return;

        context.ConfiguracaoCalculo.AddRange(
            new ConfiguracaoCalculo
            {
                ValorTotalDisponibilizado = 20000,
                SalarioMinimo = 1000,
                UpdatedDate = DateTime.Now,
                CreationDate = DateTime.Now,
                Ativo = true
            }
        );

        context.SaveChanges();
    }

    private void SetUpFuncionarios(ApiContext context)
    {
        if (context.Funcionario.Any()) return;

        context.Funcionario.AddRange(
            new Funcionario
            {
                Matricula = "MAT001",
                Nome = "Nome 01",
                AreaAtuacao = context.Peso.Where(p => p.Valor == 2 && p.TipoPeso == TipoPeso.PesoPorAreaDeAtuacao).First().Id,
                Cargo = TipoCargo.Funcionario,
                SalarioBruto = 10000,
                DataAdmissao = DateTime.Now.Subtract(new TimeSpan(2000, 0, 0, 0))
            },
            new Funcionario
            {
                Matricula = "MAT002",
                Nome = "Nome 02",
                AreaAtuacao = context.Peso.Where(p => p.Valor == 3 && p.TipoPeso == TipoPeso.PesoPorAreaDeAtuacao).First().Id,
                Cargo = TipoCargo.Funcionario,
                SalarioBruto = 6000,
                DataAdmissao = DateTime.Now.Subtract(new TimeSpan(2000, 0, 0, 0))
            }
        );

        context.SaveChanges();
    }

    private void SetUpPesos(ApiContext context)
    {
        if (context.Peso.Any()) return;

        context.Peso.AddRange(
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 1,
                Nome = "Diretoria",
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 2,
                Nome = "Contabilidade, Financeiro ou Tecnologia",
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 3,
                Nome = "Serviços Gerais",
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 4,
                Nome = "Relacionamento com o Cliente",
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorFaixaSalarial,
                Valor = 1,
                Nome = "Acima de 8 salarios-minimos",
                ValorMinimo = 8,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorFaixaSalarial,
                Valor = 2,
                Nome = "Acima de 5 salarios-minimos e abaixo de 8 salarios-minimos",
                ValorMinimo = 5,
                ValorMaximo = 8,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorFaixaSalarial,
                Valor = 3,
                Nome = "Acima de 3 salarios-minimos e abaixo de 5 salarios-minimos",
                ValorMinimo = 3,
                ValorMaximo = 5,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorFaixaSalarial,
                Valor = 5,
                Nome = "Todos os estagiarios e funcionarios que ganham ate 3 salarios-minimos",
                ValorMaximo = 3,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 1,
                Nome = "Ate 1 ano de casa",
                ValorMaximo = 1,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 2,
                Nome = "Entre 1 e 3 anos de casa",
                ValorMinimo = 1,
                ValorMaximo = 3,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 3,
                Nome = "Entre 3 e 8 anos de casa",
                ValorMinimo = 3,
                ValorMaximo = 8,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Peso
            {
                TipoPeso = TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 4,
                Nome = "Mais de 8 anos de casa",
                ValorMinimo = 8,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
        );

        context.SaveChanges();
    }
}