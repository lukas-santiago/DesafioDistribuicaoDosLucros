using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Configuration;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    public ApiContext() {}

    public virtual DbSet<Funcionario> Funcionario { get; set; }
    public virtual DbSet<ConfiguracaoCalculo> ConfiguracaoCalculo { get; set; }
    public virtual DbSet<Peso> Peso { get; set; }
    public virtual DbSet<RelatorioDistribuicao> RelatorioDistribuicao { get; set; }
    public virtual DbSet<RelatorioDistribuicaoFuncionario> RelatorioDistribuicaoFuncionario { get; set; }
    public virtual DbSet<RelatorioDistribuicaoPeso> RelatorioDistribuicaoPeso { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Peso>()
            .HasMany<Funcionario>(p => p.Funcionarios)
            .WithOne()
            .IsRequired()
            .HasForeignKey(f => f.AreaAtuacao);

        modelBuilder.Entity<RelatorioDistribuicaoFuncionario>()
            .HasOne<RelatorioDistribuicao>(r => r.RelatorioDistribuicao)
            .WithMany(s => s.RelatorioDistribuicaoFuncionario)
            .HasForeignKey(r => r.RelatorioDistribuicaoId);

        modelBuilder.Entity<RelatorioDistribuicaoPeso>()
            .HasOne<RelatorioDistribuicao>(r => r.RelatorioDistribuicao)
            .WithMany(s => s.RelatorioDistribuicaoPeso)
            .HasForeignKey(r => r.RelatorioDistribuicaoId);

    }
}