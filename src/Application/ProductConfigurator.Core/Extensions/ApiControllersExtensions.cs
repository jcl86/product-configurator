namespace Microsoft.Extensions.DependencyInjection;

public static class ApiControllersExtensions
{
    public static IServiceCollection AddControllersFromCurrentProject(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddApplicationPart(typeof(ApiControllersExtensions).Assembly);

        return services;
    }
}