using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProductConfigurator.Domain
{
    public static class AttributeExtensions
    {
        public static bool IsService(this Type type)
        {
            return Attribute.IsDefined(type, typeof(ServiceAttribute));
        }

        public static IEnumerable<Type> GetInjectableServices(params Assembly[] assemblies)
        {
            var types = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(t => t.IsService());
            return types;
        }
    }
}
