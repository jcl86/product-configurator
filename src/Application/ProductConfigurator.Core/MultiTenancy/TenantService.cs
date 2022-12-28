using Microsoft.EntityFrameworkCore;

using ProductConfigurator.Core.Database;
using ProductConfigurator.Core.Modules.Administration.Tenants;

namespace ProductConfigurator.Core.MultiTenancy;

public class TenantService : ITenantProvider
{
    public int? CurrentTenantId { get; private set; }
    
    private readonly ApplicationContext context;

    public TenantService(ApplicationContext context)
    {
        this.context = context;
    }
    
    public async Task SetTenant(int tenantId)
    {
        Tenant? tenant = await context.Set<Tenant>().FirstOrDefaultAsync(x => x.Id == tenantId);
        if (tenant is null)
        {
            throw new InvalidTenantException($"Tenant {tenantId} is not supported");
        }
        
        CurrentTenantId = tenantId;
    }
}