using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductConfigurator.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly)
                .Services;

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<ErrorHandlingConfiguration>(configuration.GetSection("ErrorHandling"));
            //services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<ErrorHandlingConfiguration>>().Value);

            return services;
        }
    }
}
