using MediatR;
using Microsoft.Extensions.DependencyInjection;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ResponseObject<Category>>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DeleteCategoryHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
         
        public async Task<ResponseObject<Category>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var catServ = scope.ServiceProvider.GetService<IDataService<Category, int>>();
                return await catServ.DeleteAsync(request.Id);
            }

        
        }
    }
}
