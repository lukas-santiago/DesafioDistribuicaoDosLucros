using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Configuration;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionario { get; set; }
    // public DbSet<ConfiguracaoCalculo> ConfiguracaoCalculo { get; set; }
    public DbSet<Peso> Peso { get; set; }
    // public DbSet<RelatorioDistribuicao> RelatorioDistribuicao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Peso>()
            .HasMany<Funcionario>(p => p.funcionarios)
            .WithOne()
            .IsRequired().HasForeignKey(f => f.AreaAtuacao);
        // .HasForeignKey<long>(f => f.AreaAtuacaoId);
    }
}