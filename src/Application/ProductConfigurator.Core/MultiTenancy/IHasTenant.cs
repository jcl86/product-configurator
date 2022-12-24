namespace ProductConfigurator.Core.MultiTenancy;
public interface IHasTenant
{
    public string TenantCode { get; internal set; }
}