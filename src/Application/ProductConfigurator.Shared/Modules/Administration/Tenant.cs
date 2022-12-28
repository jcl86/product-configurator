using System;

namespace ProductConfigurator.Shared.Modules.Administration;

public class Tenant
{
    public Guid TenantId { get; set; }
    public string Username { get; set; }
}
