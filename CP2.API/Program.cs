using CP2.API.Domain.Interfaces;
using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x => {
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Habilitar o Swagger em qualquer ambiente
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CP2.API v1");
    c.RoutePrefix = string.Empty; // Deixa o Swagger acessível na URL raiz
});

app.UseAuthorization();

app.MapControllers();

app.Run();
