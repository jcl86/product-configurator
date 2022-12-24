using Microsoft.AspNetCore.Http;

using System.Security.Claims;

namespace ProductConfigurator.Core.MultiTenancy;

public class MultiTenantMiddleware : IMiddleware
{
    private readonly TenantService companyService;

    public MultiTenantMiddleware(TenantService companyService)
    {
        this.companyService = companyService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Query.TryGetValue("company", out var values))
        {
            string? companyCode = values.FirstOrDefault();

            if (companyCode is null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Company code is not specified");
                return;
            }

            if (!UserHasPermissionInTenant(context.User, companyCode))
            {
                //Here we could raise unauthorize exception, and we would make a centralized management in a single point
                context.Response.StatusCode = 401;
                return;
            }
            companyService.SetTenant(companyCode);
        }
        await next(context);
    }

    private static bool UserHasPermissionInTenant(ClaimsPrincipal user, string companyCode)
    {
        return true; //return user.HasClaim(x => x.Type == "companyCode" && x.Value == companyCode);
    }
}