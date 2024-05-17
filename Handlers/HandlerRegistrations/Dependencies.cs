namespace REPR_API.Handlers.HandlerRegistrations
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            return services
                .AddMediatR(cfg => 
                {
                    cfg.RegisterServicesFromAssembly(typeof(Dependencies).Assembly);
                });
        }
    }
}
