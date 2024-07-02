
using Ecommerce.Model.Models;
using Ecommerce.Repositorio.DBcontext;
using Ecommerce.Repositorio.Implementacion;
using Ecommerce.Repositorio.Service;
using Ecommerce.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));

});

//no se conoce el modelo de trabajo
builder.Services.AddTransient(typeof(IGenericRepositorio<>), typeof(GenericoRepositorio<>));

//se conoce el model
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

//autoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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
