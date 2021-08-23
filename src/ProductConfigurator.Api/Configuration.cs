using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace ProductConfigurator.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            return services
                .AddHttpContextAccessor()
                .AddCustomMvc()
                //.AddAuthorization(ApiPolicies.Configure)
                .AddCustomConfiguration(configuration)
                .AddProblemDetails(environment, configuration)
                //.AddMemoryCache()
                .AddCustomApiBehaviour()
                //.AddCustomRepositories()
                .AddCustomServices();
        }

        public static IApplicationBuilder Configure(IApplicationBuilder app, Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            return configureHost(app)
                .UseProblemDetails()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync($"Welcome to Product configurator API!");
                    });
                });
        }
    }
}
