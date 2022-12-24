using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductConfigurator.Shared.Modules.Administration.Users;

public class GetUserResponse
{
    public string Id { get; }
    public string Email { get; }
    public IEnumerable<string> Roles { get; }
    
    public GetUserResponse(string id, string email, IEnumerable<string> roles)
    {
        Id = id;
        Email = email;
        Roles = roles;
    }
}
