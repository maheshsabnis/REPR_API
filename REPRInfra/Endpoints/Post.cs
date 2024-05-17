
using Azure.Core;
using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Queries.ProductQuery;
using REPR_API.REPRInfra.EndpointMapper;
using REPR_API.REPRInfra.RequestExtensions;

namespace REPR_API.Endpoints;

public class Post : IEndPointMapper
{
    IMediator mediator;
    public Post(IMediator mediator)
    {
        this.mediator = mediator;
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("post/{model}", async (HttpContext ctx, string model, EntityBase data) => {

            var requestBody = await ctx.Request.Body.ReadAsStringAsync();

            if (model == "category")
            {
                var resultCategories = await mediator.Send(new CreateCategoryCommand((Category)data));
                return Results.Ok(resultCategories);
            }
            if (model == "product")
            {
                var resultProducts = await mediator.Send(new CreateProductCommand((Product)data));
                return Results.Ok(resultProducts);
            }
            return null;
        });
    }
}