namespace ProductConfigurator.Core.MultiTenancy;

public interface ITenantProvider
{
    string? CurrentTenant { get; }
}