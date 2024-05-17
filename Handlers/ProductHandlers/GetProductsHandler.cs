using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Queries.ProductQuery;
using REPR_API.Services;

namespace REPR_API.Handlers.ProductHandlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ResponseObject<Product>>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetProductsHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<ResponseObject<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var prdServ = scope.ServiceProvider.GetService<IDataService<Product, int>>();
                return await prdServ.GetAsync();
            }
        }
    }
}
