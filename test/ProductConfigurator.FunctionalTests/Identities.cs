using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Administration.Users;

using System.Security.Claims;

namespace ProductConfigurator.FunctionalTests;

public static class Identities
{
    public static IEnumerable<Claim> FromUser(RegisterUserResponse user)
    {
        IEnumerable<Claim> roles = user.RoleNames.Select(x => new Claim(ClaimTypes.Role, x));
        return new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Email!),
            new Claim(ClaimTypes.Email, user.Email!)
        }.Concat(roles);
    }

    public static IEnumerable<Claim> SuperAdministrator => new[]
    {
        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, RoleNames.SuperAdministrator)
    };

    public static IEnumerable<Claim> PlainUser => new[]
   {
        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
    };

}
