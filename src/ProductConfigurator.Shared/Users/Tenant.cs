using System;

namespace ProductConfigurator.Domain;

public class Tenant
{
    public Guid TenantId { get; set; }
    public string Username { get; set; }
}
