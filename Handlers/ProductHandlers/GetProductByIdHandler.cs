using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Queries.ProductQuery;
using REPR_API.Services;

namespace REPR_API.Handlers.PriductHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, ResponseObject<Product>>
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetProductByIdHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<ResponseObject<Product>> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var prdServ = scope.ServiceProvider.GetService<IDataService<Product, int>>();
                return await prdServ.GetByIdAsync(request.Id);
            }
             
        }
    }
}
