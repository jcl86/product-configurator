using Microsoft.AspNetCore.Identity;

namespace ProductConfigurator.Core.Modules.Administration.Users;

public class Role : IdentityRole<string>
{
    public Role(string roleName) : base(roleName)
    {
        Id = Guid.NewGuid().ToString();
        NormalizedName = roleName.ToUpper();
        UserRoles = new List<UserRole>();
    }

    public ICollection<UserRole> UserRoles { get; set; }
}

