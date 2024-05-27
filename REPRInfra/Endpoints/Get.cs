using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Queries.ProductQuery;
using REPR_API.REPRInfra.EndpointMapper;
using REPR_API.Services;


namespace REPR_API.Endpoints;

public class Get : IEndPointMapper
{
    IMediator mediator;
    IConfiguration configuration;
    
    public Get(IMediator mediator,IConfiguration configuration)
    {
        this.mediator = mediator;
        this.configuration = configuration;
    }
    public  void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get/{model}",async(HttpContext ctx, string model) => {

            // Read the Post request Command Value from appsettings.json
            var typeName = configuration[$"API:{model}:Get"];
            // Read the Command Type Name
            var type = Type.GetType(typeName);
            
            object? queryInstance = Activator.CreateInstance(type);
            if (queryInstance != null)
            {
                var resultResponse = await mediator.Send(queryInstance);
                return Results.Ok(resultResponse);
            }
            return null;

            
           
        });
    }
}