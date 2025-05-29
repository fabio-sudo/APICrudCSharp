using ApiRestCrud.Context;
using ApiRestCrud.Interface;
using ApiRestCrud.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Esses foram colocados de forma manual
#region SQLServer Conexao do JsonConfig
// Add services to the container.
// Adiciona o serviço de DbContext ao contêiner de injeção de dependência.
// Isso permite que o Entity Framework Core seja usado na aplicação.
builder.Services.AddDbContext<AgendaContext>(options =>

    // Configura o contexto para usar o SQL Server como provedor de banco de dados.
    // A connection string é recuperada do arquivo appsettings.json pela chave "ConexaoPadrao".
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexaoPadrao") // <- Corrigido: não deve ter ponto e vírgula aqui!
    )
);
#endregion

#region Registrando Servico e Injecao de Dependencia
builder.Services.AddScoped<IContato, ContatoServico>();

builder.Services.AddScoped<ContatoServico>(); // ou AddTransient, ou AddSingleton, dependendo do seu caso
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
