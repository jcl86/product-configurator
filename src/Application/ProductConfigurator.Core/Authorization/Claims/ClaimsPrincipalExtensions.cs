using System.Security.Claims;

namespace ProductConfigurator.Core.Authorization;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserEmail(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(ClaimTypes.Email);
    }
    
    public static string? GetUserId(this ClaimsPrincipal principal)
    {
        return principal.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }

    public static string? GetUserName(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(ClaimTypes.Name);
    }
}
