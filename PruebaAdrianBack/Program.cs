using Microsoft.EntityFrameworkCore;
using PruebaAdrianBack.Models;
using PruebaAdrianBack.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEstudiantes, EstudianteService>();
builder.Services.AddScoped<ICursos, CursosService>();
builder.Services.AddScoped<IRegistro, RegistroService >();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Conexion Base de Datos

builder.Services.AddDbContext<PruebaAdrianContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("AppSettings").GetSection("DefaultConnection").Value);

});

var appSettingsSection = builder.Configuration.GetSection("AppSettings");

#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "API",
                      builder =>
                      {
                          builder.WithHeaders("*");
                          builder.WithOrigins("*");
                          builder.WithMethods("*");

                      });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("API");

app.MapControllers();

app.Run();
