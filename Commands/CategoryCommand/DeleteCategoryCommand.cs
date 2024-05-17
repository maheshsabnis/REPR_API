using MediatR;
using REPR_API.Models;

namespace REPR_API.Commands.CategoryCommand
{
    public class DeleteCategoryCommand: IRequest<ResponseObject<Category>>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
