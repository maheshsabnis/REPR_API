using MediatR;
using REPR_API.Models;
namespace REPR_API.Queries.CategoryQuery
{
    public class GetCategoriesQuery:IRequest<ResponseObject<Category>>
    {
    }
}
