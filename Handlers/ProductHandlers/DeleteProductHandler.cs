using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.ProductHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ResponseObject<Product>>
    {
       IDataService<Product, int> service;

        public DeleteProductHandler(IDataService<Product, int> service)
        {
            this.service = service;
        }
         
        public async Task<ResponseObject<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await service.DeleteAsync(request.Id);
        }
    }
}
