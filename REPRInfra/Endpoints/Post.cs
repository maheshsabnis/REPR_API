using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.REPRInfra.EndpointMapper;
using REPR_API.REPRInfra.RequestExtensions;
using REPR_API.Validators;
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

    //public void MapEndpoint(IEndpointRouteBuilder app)
    //{
    //    app.MapPost("post/{model}", async (HttpContext ctx, string model, EntityBase data) =>
    //    {
    //        ctx.Request.EnableBuffering();
    //        ctx.Request.Body.Position = 0;
    //        string requestBody = string.Empty;
    //        //using (StreamReader reader = new StreamReader(ctx.Request.Body))
    //        //{
    //        //      requestBody = await reader.ReadToEndAsync();
    //        //}

    //        requestBody = await ctx.Request.Body.ReadAsStringAsync();
    //        if (requestBody != null || requestBody.Length != 0)
    //        {
    //            if (model == "Category")
    //            {
    //                Category? category = JsonSerializer.Deserialize<Category>(requestBody);
    //                var validator = new CategoryValidator();
    //                var validationResult = validator.Validate(category);
    //                if (validationResult.IsValid)
    //                {
    //                    var resultCategories = await mediator.Send(new CreateCategoryCommand(category));
    //                    return Results.Ok(resultCategories);
    //                }
    //                return Results.BadRequest(validationResult);
    //            }
    //            if (model == "Product")
    //            {
    //                Product? product = JsonSerializer.Deserialize<Product>(requestBody);
    //                var validator = new ProductValiator();
    //                var validationResult = validator.Validate(product);
    //                if (validationResult.IsValid)
    //                {
    //                    var resultProducts = await mediator.Send(new CreateProductCommand(product));
    //                    return Results.Ok(resultProducts);
    //                }
    //                return Results.BadRequest(validationResult);
    //            }
    //        }
    //        return null;
    //    });
    //}



    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("post/{model}", async (HttpContext ctx, string model, EntityBase data) =>
        {
            if (String.IsNullOrEmpty(model))
               return Results.BadRequest("Model Value missing");

            ctx.Request.EnableBuffering();
            ctx.Request.Body.Position = 0;
            string requestBody = string.Empty;
            //using (StreamReader reader = new StreamReader(ctx.Request.Body))
            //{
            //      requestBody = await reader.ReadToEndAsync();
            //}

            requestBody = await ctx.Request.Body.ReadAsStringAsync();
            if (requestBody != null || requestBody.Length != 0)
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
                object? instance = Activator.CreateInstance(type, entityInstance);


                var resultResponse = await mediator.Send(instance);
                return Results.Ok(resultResponse);




                //if (model == "Category")
                //{
                //    Category? category = JsonSerializer.Deserialize<Category>(requestBody);
                //    var validator = new CategoryValidator();
                //    var validationResult = validator.Validate(category);
                //    if (validationResult.IsValid)
                //    {
                //        var resultCategories = await mediator.Send(new CreateCategoryCommand(category));
                //        return Results.Ok(resultCategories);
                //    }
                //    return Results.BadRequest(validationResult);
                //}
                //if (model == "Product")
                //{
                //    Product? product = JsonSerializer.Deserialize<Product>(requestBody);
                //    var validator = new ProductValiator();
                //    var validationResult = validator.Validate(product);
                //    if (validationResult.IsValid)
                //    {
                //        var resultProducts = await mediator.Send(new CreateProductCommand(product));
                //        return Results.Ok(resultProducts);
                //    }
                //    return Results.BadRequest(validationResult);
                //}
            }
            return null;
        });
    }


}
