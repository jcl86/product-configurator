using Acheve.AspNetCore.TestHost.Security;
using Acheve.TestHost;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ProductConfigurator.Core;
using ProductConfigurator.Core.Database;

using System.IdentityModel.Tokens.Jwt;

namespace ProductConfigurator.FunctionalTests.Seedwork;
public class Startup
{
    private readonly IConfiguration configuration;
    private readonly IWebHostEnvironment environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        this.configuration = configuration;
        this.environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //   string migrationsAssembly = typeof(Context).GetTypeInfo().Assembly.GetName().Name;
        string? connectionString = configuration.GetConnectionString("Labnet");
        ApiConfiguration.ConfigureServices(services, configuration)
            .AddAuthentication(TestServerDefaults.AuthenticationScheme)
            .AddTestServer(options =>
            {
                options.NameClaimType = "name";
                options.RoleClaimType = "role";
                                 
                options.Events = new TestServerEvents
                {
                    OnMessageReceived = context => Task.CompletedTask,
                    OnTokenValidated = context => Task.CompletedTask,
                    OnAuthenticationFailed = context => Task.CompletedTask,
                    OnChallenge = context => Task.CompletedTask,
                };
            });
    }

    public void Configure(IApplicationBuilder app)
    {        
        ApiConfiguration.Configure(app, host => host);
    }
}
