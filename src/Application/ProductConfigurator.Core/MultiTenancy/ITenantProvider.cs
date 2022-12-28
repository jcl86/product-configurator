namespace ProductConfigurator.Core.MultiTenancy;

public interface ITenantProvider
{
    int? CurrentTenantId { get; }
}