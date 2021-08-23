using Microsoft.Extensions.DependencyInjection;
using ProductConfigurator.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProductConfigurator.Api
{
    public static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ISendgridEmailSender,SendgridEmailSender>();

            var types = Shared.AttributeExtensions.GetInjectableServices(
                typeof(Configuration).Assembly,
                typeof(EmailSettings).Assembly
                );

            foreach (var serviceType in types)
            {
                services.AddScoped(serviceType);
            }
            return services;
        }
    }
}
