namespace ProductConfigurator.Core.MultiTenancy;

public interface IShopProvider
{
    int? CurrentShopId { get; }
}