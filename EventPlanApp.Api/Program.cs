using Microsoft.EntityFrameworkCore;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Infra.Ioc; // Import the namespace for the dependency injection setup

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para conexão com o SQL Server
builder.Services.AddDbContext<EventPlanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Usando a string de conexão do appsettings.json

// Add custom dependency injection configuration
builder.Services.AddApplicationServices(); // This will add the services from DependencyInjection

builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
