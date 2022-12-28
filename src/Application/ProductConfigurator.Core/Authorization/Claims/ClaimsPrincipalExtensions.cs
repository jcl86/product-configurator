using IdentityModel;

using System.Security.Claims;

namespace ProductConfigurator.Core.Authorization;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserEmail(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(JwtClaimTypes.Email);
    }
    
    public static string? GetUserId(this ClaimsPrincipal principal)
    {
        return principal.Claims?.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
    }

    public static string? GetUserName(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(JwtClaimTypes.Name);
    }
}
