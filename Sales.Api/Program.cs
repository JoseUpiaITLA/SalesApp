using Microsoft.EntityFrameworkCore;
using SalesApp.Infraestructure;
using SalesApp.Infraestructure.Context;
using SalesApp.AppServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SaleContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("ContextCourse")));

// Add services to the container.
builder.Services.AddInfraestructureDependency();
builder.Services.AddServicesDependency();

var originCors = builder.Configuration.GetValue<string>("CorsUrl");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins(originCors)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

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

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
