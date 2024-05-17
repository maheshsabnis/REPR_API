using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Queries.ProductQuery;
using REPR_API.Services;

namespace REPR_API.Handlers.PriductHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, ResponseObject<Product>>
    {

        IDataService<Product, int> service;

        public GetProductByIdHandler(IDataService<Product, int> service)
        {
            this.service = service;
        }

        public async Task<ResponseObject<Product>> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await service.GetByIdAsync(request.Id);
        }
    }
}
