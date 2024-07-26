using Microsoft.EntityFrameworkCore;
using REPR_API.Handlers.HandlerRegistrations;
using REPR_API.Models;

using REPR_API.REPRInfra.EndpointExtensions;
using REPR_API.Services;
using System.Reflection;

// For JSON Seriaization Policy
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;


var builder = WebApplication.CreateBuilder(args);
//1. Register Mapper

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<EshoppingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection"));
});

//2. Register all MediatR Handlers
builder.Services.RegisterRequestHandlers();
// 3. The Json Options for Serializatrion
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});
// 4. Register Services 
builder.Services.AddTransient<IDataService<Category, int>, CategoryDataService>();
builder.Services.AddTransient<IDataService<Product, int>, ProductDataService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAPIEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

//5. Map Endpoint with 'api/' as a Prefix 

app.MapAPIEndpoints(app
    .MapGroup("api/"));

// 6. To Read the HTTP Body
app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.Run();
