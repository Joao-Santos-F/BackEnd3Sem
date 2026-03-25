using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Contexto do banco de dados
builder.Services.AddDbContext<ConnectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaltConnection")));

// Repositórios
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();

builder.Services.AddEndpointsApiExplorer();

// CONFIGURAÇÃO DO SWAGGER CORRIGIDA
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ConnectPlus API",
        Description = "API para gerenciamento de contatos",
        Contact = new OpenApiContact
        {
            Name = "Joao Victor",
            Url = new Uri("https://www.linkedin.com/in/jo%C3%A3o-victor-30685635b/")
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        // Se deixar RoutePrefix vazio, o Swagger abre direto na raiz (localhost:PORTA/)
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.MapControllers();

app.Run();