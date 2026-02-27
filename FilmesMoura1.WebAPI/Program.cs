using FilmesMoura1.WebAPI.BdContextFilme;
using FilmesMoura1.WebAPI.Interfaces;
using FilmesMoura1.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o repositório ao container de injeção de dependência
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //valida quem esta solicitando
            ValidateIssuer = true,
            //valida quem esta recebendo
            ValidateAudience = true,
            //define se o tempo de expiração é valido
            ValidateLifetime = true,
            //forma de criptografia que valida a chave de autenticacao
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-atenticacao-webapi-dev")),
            //valida o tempo de expiracao do token
            ClockSkew = TimeSpan.FromMinutes(5),
            //nome do issuer, de onde está vindo o token
            ValidIssuer = "api_filmes",
            //nome do audience, para onde o token está indo
            ValidAudience = "api_filmes"
        };
    });
// Adiciona serviço de Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

// Adiciona o mapeamento de Controllers
app.MapControllers();

app.Run();
