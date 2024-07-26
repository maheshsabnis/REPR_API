using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.ProductHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ResponseObject<Product>>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DeleteProductHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<ResponseObject<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var prdServ = scope.ServiceProvider.GetService<IDataService<Product, int>>();
                return await prdServ.DeleteAsync(request.Id);
            }
            
        }
    }
}
