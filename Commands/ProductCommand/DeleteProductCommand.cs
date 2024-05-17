using MediatR;
using REPR_API.Models;

namespace REPR_API.Commands.ProductCommand
{
    public class DeleteProductCommand: IRequest<ResponseObject<Product>>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
