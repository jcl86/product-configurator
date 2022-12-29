using FluentValidation.AspNetCore;

using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ProductConfigurator.Core.Authorization;
using ProductConfigurator.Core.MultiTenancy;
using ProductConfigurator.Shared;

using System.IdentityModel.Tokens.Jwt;

namespace ProductConfigurator.Core;

public static class ApiConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddControllersFromCurrentProject()
            .AddDatabaseContexts(configuration)
            .AddCustomServices()
            .ConfigureProblemDetails()
            .AddRouting()
            .AddAuthorization(Policies.Configure)
            .CustomizeModelBindingErrorBehaviour()
            .AddMultitenancyServices()
        //    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddFluentValidationAutoValidation();
    }

    public static IApplicationBuilder Configure(IApplicationBuilder app, Func<IApplicationBuilder, IApplicationBuilder> configureHost)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        return configureHost(app)
            .UseProblemDetails()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseMiddleware<MultiTenantMiddleware>()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet(Endpoints.Health, () => Results.Ok());
            });
    }
}
