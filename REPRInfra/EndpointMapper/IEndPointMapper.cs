using REPR_API.Models;

namespace REPR_API.REPRInfra.EndpointMapper
{
    public interface IEndPointMapper
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
