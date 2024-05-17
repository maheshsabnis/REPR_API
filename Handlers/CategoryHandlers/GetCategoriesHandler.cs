using MediatR;
using REPR_API.Models;
using REPR_API.Queries.CategoryQuery;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, ResponseObject<Category>>
    {

        IDataService<Category, int> service;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetCategoriesHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;

        }
        public async Task<ResponseObject<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
               var catServ =  scope.ServiceProvider.GetService<IDataService<Category,int>>();
                return await catServ.GetAsync();
            }
            
        }
    }
}
