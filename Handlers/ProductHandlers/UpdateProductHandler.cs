using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.ProductHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResponseObject<Product>>
    {
       IDataService<Product, int> service;

        public UpdateProductHandler(IDataService<Product, int> service)
        {
            this.service = service;
        }
         
        public async Task<ResponseObject<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await service.UpdateAsync(request.Product.ProductUniqueId,request.Product);
        }
    }
}
