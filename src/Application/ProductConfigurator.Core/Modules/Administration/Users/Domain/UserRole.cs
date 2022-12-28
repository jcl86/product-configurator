using Microsoft.AspNetCore.Identity;

namespace ProductConfigurator.Core.Modules.Administration.Users;

public class UserRole : IdentityUserRole<string>
{
    public Role? Role { get; set; }
    public User? User { get; set; }
}