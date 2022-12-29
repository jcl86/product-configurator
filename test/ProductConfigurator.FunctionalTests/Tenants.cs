using ProductConfigurator.Core.Modules.Administration.Tenants;

namespace ProductConfigurator.FunctionalTests;

public static class Tenants
{
    public const int Tenant1 = 1;
    public const int Tenant2 = 2;

    public static Tenant[] All
    {
        get
        {
            return new Tenant[]
            {
                new Tenant(Tenant1, DateTime.UtcNow)
                {
                    Code = nameof(Tenant1),
                    Name = nameof(Tenant1),
                },
                new Tenant(Tenant2, DateTime.UtcNow)
                {
                    Code = nameof(Tenant2),
                    Name = nameof(Tenant2),
                },
            };
        }
    }
}
