using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductConfigurator.Shared.Modules.Administration.Users;

public class ListUserResponse
{
    public IEnumerable<UserItem> Users { get; init; }
    public ListUserResponse(IEnumerable<UserItem> users)
    {
        Users = users;
    }

    public class UserItem
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public IEnumerable<string> Roles { get; init; }

        public UserItem(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
        }
    }
}
