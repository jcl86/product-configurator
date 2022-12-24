using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using static SuperErp.Management.Model.Endpoints;
using SuperErp.Management.Model;
using System.Globalization;

namespace ProductConfigurator.Core.Modules.Administration.Users;

public class User : IdentityUser
{
    public ICollection<IdentityUserClaim<string>> Claims { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public IEnumerable<string> RoleNames => UserRoles
        .Select(x => x.Role?.Name)
        .Where(x => x is not null)
        .Select(x => x!).ToList() ?? new List<string>();
    
    public User(EmailAddress emailAddress)
    {
        UserName = emailAddress.ToString();
        Email = emailAddress.ToString();
        UserRoles = new List<UserRole>();
        Claims = new List<IdentityUserClaim<string>>();
    }
}
