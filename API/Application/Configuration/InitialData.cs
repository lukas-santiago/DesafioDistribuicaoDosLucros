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
                ValorTotalDisponibilizado = 0,
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
                TipoPeso = Models.Enum.TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 1,
                Nome = "Diretoria",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 2,
                Nome = "Contabilidade, Financeiro ou Tecnologia",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 3,
                Nome = "Serviços Gerais",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorAreaDeAtuacao,
                Valor = 4,
                Nome = "Relacionamento com o Cliente",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorFaixaSalarial,
                Valor = 1,
                Nome = "Acima de 8 salarios-minimos",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorFaixaSalarial,
                Valor = 2,
                Nome = "Acima de 5 salarios-minimos e abaixo de 8 salarios-minimos",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorFaixaSalarial,
                Valor = 3,
                Nome = "Acima de 3 salarios-minimos e abaixo de 5 salarios-minimos",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorFaixaSalarial,
                Valor = 5,
                Nome = "Todos os estagiarios e funcionarios que ganham ate 3 salarios-minimos",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 1,
                Nome = "Ate 1 ano de casa",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 2,
                Nome = "Entre 1 e 3 anos de casa",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 3,
                Nome = "Entre 3 e 8 anos de casa",
            },
            new Peso
            {
                TipoPeso = Models.Enum.TipoPeso.PesoPorTempoDeAdmissao,
                Valor = 4,
                Nome = "Mais de 8 anos de casa",
            }
        );

        context.SaveChanges();
    }
}