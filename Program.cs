using Datos.DataDb;
using Microsoft.EntityFrameworkCore;
using Repositorios.Estudiante;
using Servicio.Estudiante;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opcion => opcion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

builder.Services.AddTransient<IEstudianteRepositorio, EstudianteRepositorio>();
builder.Services.AddScoped<IEstudianteServicio, EstudianteServicio>();

// agregamos CORS
//builder.Services.AddCors(options => {
//    options.AddPolicy("NewPolitic", app => {
//        app.AllowAnyOrigin()
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//    });
//});

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
