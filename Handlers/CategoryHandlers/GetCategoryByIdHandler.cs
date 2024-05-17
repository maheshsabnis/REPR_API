using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, ResponseObject<Category>>
    {

        IDataService<Category, int> service;

        public GetCategoryByIdHandler(IDataService<Category, int> service)
        {
            this.service = service;
        }
        public async Task<ResponseObject<Category>> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            return await service.GetByIdAsync(request.Id);
        }
    }
}
