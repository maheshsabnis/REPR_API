using MediatR;
using REPR_API.Models;
namespace REPR_API.Queries.ProductQuery
{
    public class GetProductsQuery:IRequest<ResponseObject<Product>>
    {
    }
}
