using Microsoft.Extensions.DependencyInjection;

namespace ProductConfigurator.Core.MultiTenancy;

public static class MultitenancyExtensions
{
    public static IServiceCollection AddMultitenancyServices(this IServiceCollection services)
    {
        services.AddTransient<MultiTenantMiddleware>();
        services.AddScoped<TenantService>();
        services.AddScoped<IShopProvider>(provider => provider.GetRequiredService<TenantService>());
        return services;
    }
}