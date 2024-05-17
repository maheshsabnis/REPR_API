using Asp.Versioning;
using Asp.Versioning.Builder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REPR_API.Handlers.HandlerRegistrations;
using REPR_API.Models;
 
using REPR_API.REPRInfra.EndpointExtensions;
using REPR_API.Services;
using System.Reflection;
 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<EshoppingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection"));
});


builder.Services.RegisterRequestHandlers();

builder.Services.AddTransient<IDataService<Category, int>, CategoryDataService>();
builder.Services.AddTransient<IDataService<Product, int>, ProductDataService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

 
RouteGroupBuilder versionedGroup = app
    .MapGroup("api/");
   

app.MapEndpoints(versionedGroup);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
