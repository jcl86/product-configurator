using IdentityModel;

using ProductConfigurator.Core.Authorization;
using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Administration.Users;

using System.Security.Claims;

namespace ProductConfigurator.FunctionalTests;

public static class Identities
{
    public static IEnumerable<Claim> FromUser(RegisterUserResponse user)
    {
        IEnumerable<Claim> roles = user.Roles.Select(x => new Claim(ClaimTypes.Role, x));
        return new[]
        {
            new Claim(JwtClaimTypes.Subject, user.Id),
            new Claim(JwtClaimTypes.Name, user.Email!),
            new Claim(JwtClaimTypes.Email, user.Email!)
        }.Concat(roles);
    }

    public static IEnumerable<Claim> SuperAdministrator => new[]
    {
        new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString()),
        new Claim(JwtClaimTypes.Name, "admin"),
        new Claim(JwtClaimTypes.Role, RoleNames.SuperAdministrator)
    };

    public static IEnumerable<Claim> FromTenant(int tenantId) => new[]
    {
        new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString()),
        new Claim(JwtClaimTypes.Name, "anyPlainUser"),
        new Claim(CustomClaimTypes.TenantId, tenantId.ToString()),
    };
}
