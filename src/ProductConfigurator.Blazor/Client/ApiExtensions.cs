using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProductConfigurator.Blazor
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new ClientSettings();
            configuration.Bind("ClientSettings", settings);

            services.AddHttpClient<ApiClient>(cl =>
            {
                cl.BaseAddress = new Uri(settings.BaseUrl);
            });

            return services;
        }
    }
}
