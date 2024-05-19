using AluguelCarrosV2.Data;
using AluguelCarrosV2.Inteface.Repository;
using AluguelCarrosV2.Inteface.Service;
using AluguelCarrosV2.Repository;
using AluguelCarrosV2.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CarrosConnection");

// Configuração do Entity Framework Core
builder.Services.AddDbContext<SqlContext>(opts => opts.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aluguel de Carros API", Version = "v1" });
});

// Configuração dos outros serviços
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aluguel de Carros API v2"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(p => {
    p.AllowAnyMethod();
    p.AllowAnyHeader();
    p.AllowAnyOrigin();
});
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();
