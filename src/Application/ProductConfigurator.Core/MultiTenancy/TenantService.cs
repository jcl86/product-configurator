using Microsoft.EntityFrameworkCore;

using ProductConfigurator.Core.Database;
using ProductConfigurator.Core.Modules.Administration.Shops;

namespace ProductConfigurator.Core.MultiTenancy;

public class TenantService : IShopProvider
{
    public int? CurrentShopId { get; private set; }
    
    private readonly AdminContext context;

    public TenantService(AdminContext context)
    {
        this.context = context;
    }
    
    public async Task SetTenant(int tenantId)
    {
        Shop? shop = await context.Set<Shop>().FirstOrDefaultAsync(x => x.Id == tenantId);
        if (shop is null)
        {
            throw new InvalidTenantException($"Tenant id {tenantId} does not match with an existing shop");
        }
        
        CurrentShopId = tenantId;
    }
}