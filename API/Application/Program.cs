using System.Text.Json.Serialization;
using Application.Configuration;
using Application.Middlewares;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

{
    builder.Services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("DesafioDistribuicaoDosLucrosDB"));
    builder.Services.AddScoped<InitialDataGenerator>();

    builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
    builder.Services.AddScoped<IConfiguracaoCalculoService, ConfiguracaoCalculoService>();
    builder.Services.AddScoped<IPesoService, PesoService>();
    builder.Services.AddScoped<IRelatorioDistribuicaoService, RelatorioDistribuicaoService>();
}

var app = builder.Build();
{
    //Middlewares
    app.UseMiddleware(typeof(GlobalErrorHandlerMiddleware));
    app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<InitialDataGenerator>();
    }

    // app.UseHttpsRedirection(); // For local development
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}