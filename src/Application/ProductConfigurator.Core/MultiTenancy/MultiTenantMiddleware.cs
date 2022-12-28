using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

using ProductConfigurator.Core.Authorization;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

using System.Linq;
using System.Security.Claims;

namespace ProductConfigurator.Core.MultiTenancy;

public class MultiTenantMiddleware : IMiddleware
{
    private readonly string[] requestsToSkip = 
    {
        Endpoints.Accounts.Login ,
        Endpoints.Accounts.ChangePassword,
        Endpoints.Accounts.ResetPassword
    };

    private readonly TenantService tenantService;

    public MultiTenantMiddleware(TenantService tenantService)
    {
        this.tenantService = tenantService;
        requestsToSkip = requestsToSkip.Select(x => $"/{x}").ToArray();
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.HasValue && requestsToSkip.Contains(context.Request.Path.Value))
        {
            await next(context);
            return;
        }
        
        if (!context.Request.Headers.TryGetValue("Tenant", out StringValues values))
        {
            throw new InvalidTenantException();
        }
        
        string? tenantCode = values.FirstOrDefault();

        if (tenantCode is null)
        {
            throw new InvalidTenantException();
        }

        if (!int.TryParse(tenantCode, out int parsedTenant))
        {
            throw new InvalidTenantException(tenantCode);
        }

        if (!UserHasPermissionInTenant(context.User, tenantCode))
        {
            throw new InvalidTenantException(tenantCode);
        }
            
        await tenantService.SetTenant(parsedTenant);
        
        await next(context);
    }

    private static bool UserHasPermissionInTenant(ClaimsPrincipal user, string tenantId)
    {
        if (user.IsInRole(RoleNames.SuperAdministrator))
        {
            return true;
        }
        return user.HasClaim(x => x.Type == CustomClaimTypes.TenantId && x.Value == tenantId);
    }
}
