using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared;

using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class CustomServicesExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        IEnumerable<Type> serviceTypes = new List<Assembly>()
        {
           typeof(UserFinder).Assembly
        }
         .SelectMany(x => x.GetTypes())
         .Where(t => Attribute.IsDefined(t, typeof(ServiceAttribute)));

        foreach (Type serviceType in serviceTypes)
        {
            services.AddScoped(serviceType);
        }
        
        return services;
    }
}

