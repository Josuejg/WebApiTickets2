using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
using WebApiTikects.DataBase;
using WebApiTikects.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextoBD>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MiConexion")));

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();

Usuarios usuario = new Usuarios
{
    us_nombre_completo = "Ana Pérez",
    us_correo = "ana.perez@email.com",
    us_estado = "A"
};

var sb = new StringBuilder();
sb.Append("Nombre: ").Append(usuario.us_nombre_completo).AppendLine();
sb.Append("Correo: ").Append(usuario.us_correo).AppendLine();
sb.Append("Estado: ").Append(usuario.us_estado);

// Resultado final
string resumenUsuario = sb.ToString();
Console.WriteLine(resumenUsuario);
