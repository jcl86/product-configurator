namespace ProductConfigurator.Core.MultiTenancy;
public interface IHasTenant
{
    public int? TenantId { get; set; }
}
