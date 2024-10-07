using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NewLibrary.ConfigJWT;
using NewLibrary.Data;
using NewLibrary.Repositories;
using NewLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

//load eviroment variables 

Env.Load(); //para llamar las variables de entorno que estan en el archivo .env
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");



var ConnectionDB = $"server={dbHost}; port={dbPort}; database={dbDatabase}; uid={dbUser}; password={dbPassword}";
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseMySql(ConnectionDB, ServerVersion.Parse("8.0.20-mysql")));

//ACA AGREGAMOS LOS SERVICIOS QUE NOS PERMITE TRABAJAR CON LIBROS

builder.Services.AddScoped<IBookRepository, BookServices>(); //revisar
builder.Services.AddScoped<IuserRepository, UserServices>();
builder.Services.AddScoped<IAuthRepository, AuthService>();


// ACA HABILITAMOS LA OPCION QUE NOS PERMITE USAR JWT
builder.Services.AddSingleton<JWT>();
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
        ValidateAudience = false,
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!))
    };
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(C =>
{
    C.SwaggerDoc("v1", new OpenApiInfo { Title = "NEWLIBRARY", Version = "V1" });

    C.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    C.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    //Habilita las anotaciones Swagger
    C.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //autenticar que los endpoints se puedan asegurar

app.UseAuthorization();

app.MapControllers();

app.Run();
