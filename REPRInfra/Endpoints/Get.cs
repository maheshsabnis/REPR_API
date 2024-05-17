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
    
    public Get(IMediator mediator)
    {
        this.mediator = mediator;
    }
    public  void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get/{model}",async(HttpContext ctx, string model) => {
            if (model == "category")
            {
                var resultCategories = await mediator.Send(new GetCategoriesQuery());
                return Results.Ok(resultCategories);
            }
            if (model == "product")
            {
                var resultProducts = await mediator.Send(new GetProductsQuery());
                return Results.Ok(resultProducts);
            }
            return null;
        });
    }
}