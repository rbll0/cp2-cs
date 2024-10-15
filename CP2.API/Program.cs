using CP2.API.Domain.Interfaces;
using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Infrastructure.Data.Repositories;
using CP2.API.Application.Interfaces;
using CP2.API.Application.Services; // Certifique-se de que a implementação está aqui
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x => {
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

// Registrar o repositório e os serviços de aplicação
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();

builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();
builder.Services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();  // Adicionando o serviço correto

builder.Services.AddControllers();

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CP2.API v1");
    c.RoutePrefix = string.Empty; // Deixa o Swagger acessível na URL raiz
});

app.UseAuthorization();
app.MapControllers();
app.Run();
