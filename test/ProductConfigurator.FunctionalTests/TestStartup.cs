using Acheve.AspNetCore.TestHost.Security;
using Acheve.TestHost;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace ProductConfigurator.FunctionalTests
{
    public class TestStartup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public TestStartup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //   string migrationsAssembly = typeof(Context).GetTypeInfo().Assembly.GetName().Name;
            string connectionString = configuration.GetConnectionString("Labnet");

            Api.Configuration.ConfigureServices(services, environment, configuration)
                .AddAuthorization()
                ////.AddDbContext<ApplicationContext>(options =>
                ////{
                ////    options.UseSqlServer(connectionString);
                ////})
                .AddAuthentication(setup =>
                {
                    setup.DefaultAuthenticateScheme = TestServerDefaults.AuthenticationScheme;
                    setup.DefaultChallengeScheme = TestServerDefaults.AuthenticationScheme;

                    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
                })
                .AddTestServer(options =>
                {
                    options.NameClaimType = "name";
                    options.RoleClaimType = "role";
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
            //    var connectionStrings = serviceScope.ServiceProvider.GetRequiredService<IConnectionStrings>();

            //    new DataBaseInitializer(context, connectionStrings).Initialize();
            //}

            Api.Configuration.Configure(app, host => host);
        }
    }
}
