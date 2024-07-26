using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Queries.ProductQuery;
using REPR_API.REPRInfra.EndpointMapper;
using REPR_API.Services;

namespace REPR_API.Endpoints;

public class GetById : IEndPointMapper
{
    IMediator mediator;
    IConfiguration configuration;
    
    public GetById(IMediator mediator,IConfiguration configuration)
    {
        this.mediator = mediator;
        this.configuration = configuration;
    }
    public  void MapAPIEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get/{model}/{id}",async(string model,int id) => {

            // Read the Post request Command Value from appsettings.json
            var typeName = configuration[$"API:{model}:GetById"];
            // Read the Command Type Name
            var type = Type.GetType(typeName);
            
            object? queryInstance = Activator.CreateInstance(type,id);
            if (queryInstance != null)
            {
                var resultResponse = await mediator.Send(queryInstance);
                return Results.Ok(resultResponse);
            }
            return null;

           
           
        });
    }
}