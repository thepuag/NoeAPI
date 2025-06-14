// Program.cs actualizado con comprobación y aplicación de migraciones
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.DAL.Repositories;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.BLL.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configuración de cadena de conexión según entorno
var environment = builder.Environment.EnvironmentName;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
    throw new Exception("Cadena de conexión no encontrada");

// Servicios base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();

// Servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IAlmacenService, AlmacenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// JWT
var jwtKey = builder.Configuration["Jwt:Key"] ?? Environment.GetEnvironmentVariable("Jwt__Key");
var key = Encoding.ASCII.GetBytes(jwtKey!);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// CORS
builder.Services.AddCors(options =>
{
#if DEBUG // Desarrollo
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
#else    // Producción
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
#endif
});

var app = builder.Build();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Migraciones automáticas
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Console.WriteLine("Aplicando migraciones pendientes si las hay...");
    db.Database.Migrate();
}

app.Run();
