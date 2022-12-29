using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductConfigurator.Shared.Modules.Administration.Users;

public class GetUserResponse
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public int? TenantId { get; set; }
    public required IEnumerable<string> Roles { get; set; }
}
