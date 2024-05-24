using MediatR;
using REPR_API.Models;

namespace REPR_API.Queries.CategoryQuery
{
    public class GetCategoryByIdQuery:IRequest<ResponseObject<Category>>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
