using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ResponseObject<Category>>
    {
       IDataService<Category,int> service;

        public DeleteCategoryHandler(IDataService<Category, int> service)
        {
            this.service = service;
        }
         
        public async Task<ResponseObject<Category>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await service.DeleteAsync(request.Id);
        }
    }
}
