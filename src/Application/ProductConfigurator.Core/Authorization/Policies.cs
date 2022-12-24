using Microsoft.AspNetCore.Authorization;

using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Authorization;

public static class Policies
{
    public const string IsSuperAdministrator = nameof(IsSuperAdministrator);

    public static void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(IsSuperAdministrator, policyBuilder =>
        {
            policyBuilder.RequireAuthenticatedUser();
            policyBuilder.RequireRole(RoleNames.SuperAdministrator);
        });
    }
}