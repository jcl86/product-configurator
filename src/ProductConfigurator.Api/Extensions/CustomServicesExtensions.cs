using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProductConfigurator.Api
{
    public static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            var types = Shared.AttributeExtensions.GetInjectableServices(
                typeof(Configuration).Assembly
                );

            foreach (var serviceType in types)
            {
                services.AddScoped(serviceType);
            }
            return services;
        }
    }
}
