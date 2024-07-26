using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, ResponseObject<Category>>
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetCategoryByIdHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task<ResponseObject<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var catServ = scope.ServiceProvider.GetService<IDataService<Category, int>>();
                return await catServ.GetByIdAsync(request.Id);
            }
           
        }
    }
}
