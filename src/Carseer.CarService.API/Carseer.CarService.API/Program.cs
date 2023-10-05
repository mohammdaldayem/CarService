using System.Net.Http;
using Carseer.CarService.API;
using Carseer.CarService.Application.CarMakes;
using Carseer.CarService.Contracts.CarMakes;
using Carseer.CarService.Domain.CarMakes;
using Carseer.CarService.EntityFrameworkCore.CarMakes;
using Carseer.CarService.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarServiceDBContext>();
builder.Services.AddHttpClient<VpicService>();
builder.Services.AddScoped<ICarMakeRepository, EfCoreCarMakeRepository>();
builder.Services.AddTransient<ICarMakeService, CarMakeService>();
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


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetService<CarServiceDBContext>();
    DataSeeder.SeedCarMake(context);
}


app.Run();
