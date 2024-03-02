using Microsoft.EntityFrameworkCore;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Dao;
using SalesApp.Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SaleContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("ContextCourse")));

// Add services to the container.
builder.Services.AddTransient<ICategoriaDb, CategoriaDb>();

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
