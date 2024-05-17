using MediatR;
using REPR_API.Models;

namespace REPR_API.Commands.ProductCommand
{
    public class CreateProductCommand: IRequest<ResponseObject<Product>>
    {
        public Product? Product { get; set; }

        public CreateProductCommand(Product prd)
        {
            Product = prd;   
        }
    }
}
