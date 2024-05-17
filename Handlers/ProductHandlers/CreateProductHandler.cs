using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Commands.ProductCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.ProductHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ResponseObject<Product>>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CreateProductHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<ResponseObject<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var prdServ = scope.ServiceProvider.GetService<IDataService<Product, int>>();
                return await prdServ.CreateAsync(request.Product);
            }
        }
    }
}
