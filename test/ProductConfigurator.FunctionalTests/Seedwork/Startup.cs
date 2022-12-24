using Acheve.AspNetCore.TestHost.Security;
using Acheve.TestHost;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ProductConfigurator.Core;

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
        IServiceScopeFactory? serviceProvider = app.ApplicationServices.GetService<IServiceScopeFactory>();
        
        if (serviceProvider is null)
        {
            throw new Exception("Service provider could not be obtained in Test Startup.Configure");
        }

        using (IServiceScope serviceScope = serviceProvider.CreateScope())
        {
            //var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
            //var connectionStrings = serviceScope.ServiceProvider.GetRequiredService<IConnectionStrings>();

            //new DataBaseInitializer(context, connectionStrings).Initialize();
        }
        ApiConfiguration.Configure(app, host => host);
    }
}
