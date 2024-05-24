
using MediatR;
using REPR_API.REPRInfra.EndpointMapper;

namespace REPR_API.Endpoints;

public class Delete : IEndPointMapper
{

    IMediator mediator;
    IConfiguration configuration;
    public Delete(IMediator mediator, IConfiguration configuration)
    {
        this.mediator = mediator;
        this.configuration = configuration;

    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("delete/{model}/{id}", async (string model, int id) => {
            // Read the Post request Command Value from appsettings.json
            var typeName = configuration[$"API:{model}:Delete"];
            // Read the Command Type Name
            var type = Type.GetType(typeName);
            object? commandInstance = Activator.CreateInstance(type,id);
            var resultResponse = await mediator.Send(commandInstance);
            return Results.Ok(resultResponse);
        });
    }
}