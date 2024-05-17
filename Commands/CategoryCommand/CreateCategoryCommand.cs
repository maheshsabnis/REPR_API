using MediatR;
using REPR_API.Models;

namespace REPR_API.Commands.CategoryCommand
{
    public class CreateCategoryCommand: IRequest<ResponseObject<Category>>
    {
        public Category? Category { get; set; }

        public CreateCategoryCommand(Category cat)
        {
            Category = cat;   
        }
    }
}
