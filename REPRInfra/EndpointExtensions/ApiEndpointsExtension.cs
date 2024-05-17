using Microsoft.Extensions.DependencyInjection.Extensions;
using REPR_API.REPRInfra.EndpointMapper;
using System.Reflection;

namespace REPR_API.REPRInfra.EndpointExtensions
{
    public static class ApiEndpointsExtension
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly asm)
        {
            ServiceDescriptor[] serviceDescriptors = asm
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                               type.IsAssignableTo(typeof(IEndPointMapper)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndPointMapper), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IEndPointMapper> endpoints = app.Services.GetRequiredService<IEnumerable<IEndPointMapper>>();

            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (IEndPointMapper endpoint in endpoints)
            {
                endpoint.MapEndpoint(builder);
            }

            return app;
        }
    }
}
