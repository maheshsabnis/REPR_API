using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateCategoryCommand, ResponseObject<Category>>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CreateProductHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
         
        public async Task<ResponseObject<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var catServ = scope.ServiceProvider.GetService<IDataService<Category, int>>();
                return await catServ.CreateAsync(request.Category);
            }
        }
    }
}
