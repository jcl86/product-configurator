using Microsoft.AspNetCore.Identity;

using ProductConfigurator.Core.MultiTenancy;

namespace ProductConfigurator.Core.Modules.Administration.Users;

public class User : IdentityUser, IHasTenant
{
    public ICollection<IdentityUserClaim<string>> Claims { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public IEnumerable<string> RoleNames => UserRoles
        .Select(x => x.Role?.Name)
        .Where(x => x is not null)
        .Select(x => x!).ToList() ?? new List<string>();

    public int? TenantId { get; set; }

    private User() 
    {
        UserRoles = new List<UserRole>();
        Claims = new List<IdentityUserClaim<string>>();
    }
    
    public User(EmailAddress emailAddress) : this()
    {
        UserName = emailAddress.ToString();
        Email = emailAddress.ToString();
    }
}
