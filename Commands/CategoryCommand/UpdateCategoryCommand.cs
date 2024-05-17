using MediatR;
using REPR_API.Models;

namespace REPR_API.Commands.CategoryCommand
{
    public class UpdateCategoryCommand: IRequest<ResponseObject<Category>>
    {
        public Category? Category { get; set; }

        public UpdateCategoryCommand(Category cat)
        {
            Category = cat;   
        }
    }
}
