using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductConfigurator.Shared.Modules.Administration.Users;

public class ListUserResponse
{
    public required IEnumerable<UserItem> Users { get; set; }
    
    public class UserItem
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public int? TenantId { get; set; }
        public required IEnumerable<string> Roles { get; set; }
    }
}
