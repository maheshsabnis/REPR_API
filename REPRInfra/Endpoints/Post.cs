using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.REPRInfra.EndpointMapper;
using REPR_API.REPRInfra.RequestExtensions;
using REPR_API.Validators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
 

namespace REPR_API.Endpoints;

public class Post : IEndPointMapper
{
    IMediator mediator;
    IConfiguration configuration;
    public Post(IMediator mediator, IConfiguration configuration)
    {
        this.mediator = mediator;
        this.configuration = configuration;

    }

    



    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("post/{model}", async (HttpContext ctx, string model, EntityBase data) =>
        {
            if (String.IsNullOrEmpty(model))
               return Results.BadRequest("Model Value missing");

            ctx.Request.EnableBuffering();
            ctx.Request.Body.Position = 0;
            string requestBody = string.Empty;
            

            requestBody = await ctx.Request.Body.ReadAsStringAsync();
            if (requestBody != null || requestBody?.Length != 0)
            {
                try
                {
                    // Read the Post request Command Value from appsettings.json
                    var typeName = configuration[$"API:{model}:Post"];
                    // Read the Command Type Name
                    var type = Type.GetType(typeName);
                    // Read the Model ENtity Name
                    var entityTypeName = configuration[$"API:{model}:Model"];
                    // Read the Model Entity Type
                    var entityType = Type.GetType(entityTypeName);


                    // Store data from Body into the Entity Object and create its instance
                    object? entityInstance = JsonSerializer.Deserialize(requestBody, entityType);
                    // Create an Instance of Command
                    object? commandInstance = Activator.CreateInstance(type, entityInstance);

                    // Read the Validator class from the appsettings file 
                    var validatorTypeName = configuration[$"API:{model}:Validator"];
                    var validationResult = ModelValidator.IsValid(validatorTypeName, entityInstance);

                    if (validationResult.IsValid)
                    {
                        var resultResponse = await mediator.Send(commandInstance);
                        return Results.Ok(resultResponse);
                    }
                    else
                    {
                        return Results.BadRequest(validationResult.Errors.Select(e=>e.ErrorMessage).ToList());
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return null;
        });
    }


}
