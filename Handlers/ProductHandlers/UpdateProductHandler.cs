using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.ProductHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResponseObject<Product>>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UpdateProductHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<ResponseObject<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var prdServ = scope.ServiceProvider.GetService<IDataService<Product, int>>();
                return await prdServ.UpdateAsync(request.Product.ProductUniqueId, request.Product);
            }
        }
    }
}
