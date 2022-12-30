using ProductConfigurator.Core.Modules.Administration.Shops;

namespace ProductConfigurator.FunctionalTests;

public static class Tenants
{
    public const int Tenant1 = 1;
    public const int Tenant2 = 2;

    public static Shop[] All
    {
        get
        {
            return new Shop[]
            {
                new Shop(Tenant1, DateTime.UtcNow)
                {
                    Code = nameof(Tenant1),
                    Name = nameof(Tenant1),
                },
                new Shop(Tenant2, DateTime.UtcNow)
                {
                    Code = nameof(Tenant2),
                    Name = nameof(Tenant2),
                },
            };
        }
    }
}
