namespace ProductConfigurator.Core.MultiTenancy;

public class InvalidTenantException  : Exception
{
    public InvalidTenantException(string tenantCode) : base($"Invalid tenant {tenantCode}")
    {
    }

    public InvalidTenantException() : base("A valid tenant must be specified")
    {
    }
}
