using Microsoft.Extensions.DependencyInjection.Extensions;
using REPR_API.REPRInfra.EndpointMapper;
using System.Reflection;

namespace REPR_API.REPRInfra.EndpointExtensions
{
    public static class ApiEndpointsExtension
    {
        public static IServiceCollection AddAPIEndpoints(this IServiceCollection services, Assembly assembly)
        {
            // Get All Se`rvices 
            ServiceDescriptor[] serviceDescriptors = assembly
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                               type.IsAssignableTo(typeof(IEndPointMapper)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndPointMapper), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }
        /// <summary>
        /// Map All Endpoints to Route in the HTTP Pipeline to Execute when the 
        /// HTTP Request is received 
        /// RouteGroupBuilder: This is used to define a Group of Endpoints with a common prefix
        /// </summary>
        /// <param name="app"></param>
        /// <param name="routeGroupBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder MapAPIEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IEndPointMapper> endpoints = app.Services.GetRequiredService<IEnumerable<IEndPointMapper>>();
           
            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (IEndPointMapper endpoint in endpoints)
            {
                // Map Endpoints
                endpoint.MapAPIEndpoint(builder);
            }

            return app;
        }
    }
}
