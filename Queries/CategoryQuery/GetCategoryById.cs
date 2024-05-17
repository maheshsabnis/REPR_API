using MediatR;
using REPR_API.Models;

namespace REPR_API.Queries.CategoryQuery
{
    public class GetCategoryById:IRequest<ResponseObject<Category>>
    {
        public int Id { get; set; }
    }
}
