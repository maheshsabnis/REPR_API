using MediatR;
using REPR_API.Commands.CategoryCommand;
using REPR_API.Models;
using REPR_API.Services;

namespace REPR_API.Handlers.CategoryHandlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ResponseObject<Category>>
    {
       IDataService<Category,int> service;

        public UpdateCategoryHandler(IDataService<Category, int> service)
        {
            this.service = service;
        }
         
        public async Task<ResponseObject<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await service.UpdateAsync(request.Category.CategoryUniqueId,request.Category);
        }
    }
}
