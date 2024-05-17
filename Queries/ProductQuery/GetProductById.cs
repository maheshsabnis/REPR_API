using MediatR;
using REPR_API.Models;

namespace REPR_API.Queries.ProductQuery
{
    public class GetProductById:IRequest<ResponseObject<Product>>
    {
        public int Id { get; set; }
    }
}
