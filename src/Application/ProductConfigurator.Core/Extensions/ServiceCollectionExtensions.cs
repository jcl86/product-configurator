using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using ProductConfigurator.Domain;

namespace ProductConfigurator.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
        services
            .AddControllers()
            .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly)
            .Services;

    public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<EmailSettings>>().Value);

        return services;
    }
}

