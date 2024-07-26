using REPR_API.Models;

namespace REPR_API.REPRInfra.EndpointMapper
{
    public interface IEndPointMapper
    {
        void MapAPIEndpoint(IEndpointRouteBuilder app);
    }
}
