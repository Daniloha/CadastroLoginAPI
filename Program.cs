using APICadastro.Models.Context;
using APICadastro.Models.Services;
using APICadastro.Models.Services.Implementations;
using Microsoft.EntityFrameworkCore;


// Criação da aplicação
var builder = WebApplication.CreateBuilder(args);

// Registro do serviço IPersonService
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

// Adiciona os controladores ao container
builder.Services.AddControllers();

// Obtém a string de conexão corretamente
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura o DbContext com a string de conexão
builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Número máximo de tentativas de reconexão
            maxRetryDelay: TimeSpan.FromSeconds(10), // Tempo máximo de espera entre as tentativas
            errorNumbersToAdd: null)) // Números de erro adicionais para considerar como falhas transitórias
    .EnableSensitiveDataLogging() // Para logs detalhados
    .EnableDetailedErrors());

// Versionamento da API    
builder.Services.AddApiVersioning();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
app.UseHttpsRedirection();

// Configuração dos middlewares
app.UseAuthorization();

// Configuração dos controladores
app.MapControllers();

// Inicia a aplicação
app.Run();
