using MediatR;
using REPR_API.Models;

namespace REPR_API.Commands.ProductCommand
{
    public class UpdateProductCommand: IRequest<ResponseObject<Product>>
    {
        public Product? Product { get; set; }

        public UpdateProductCommand(Product prd)
        {
            Product = prd;   
        }
    }
}
