using System.Reflection;

namespace ProductConfigurator.Shared;

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
