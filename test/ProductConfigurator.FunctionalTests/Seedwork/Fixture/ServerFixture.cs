using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Polly;

using ProductConfigurator.FunctionalTests.Seedwork;

using System.IO;

using Xunit;

namespace ProductConfigurator.FunctionalTests.Seedwork.Fixture;

public class ServerFixture : IAsyncLifetime
{
    private IWebHost? host;

    public TestServer Server => host.GetTestServer();

    public T GetService<T>() => (T)Server.Services.GetService(typeof(T));

    public ServerFixture() { }

    public void Dispose()
    {
        Server.Dispose();
        host?.Dispose();
    }

    public async Task InitializeAsync()
    {
        host = new WebHostBuilder()
                  .UseTestServer()
                  .UseStartup<Startup>()
                  .UseEnvironment("Development")
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .ConfigureAppConfiguration(app =>
                  {
                      app.AddJsonFile("FunctionalTestsSettings.json", optional: true);
                      app.AddUserSecrets(typeof(ServerFixture).Assembly, optional: true);
                      app.AddEnvironmentVariables();
                  }).Build();

        await MigrateDbContext();

        await host.StartAsync();
    }

    public async Task MigrateDbContext()
    {
        //using (IServiceScope scope = host.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;
        //    var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();
        //    var context = services.GetService<ApplicationDbContext>();

        //    try
        //    {
        //        logger.LogInformation($"Migrating database associated with context");
        //        var retry = Policy.Handle<Exception>().WaitAndRetry(new[]
        //        {
        //                TimeSpan.FromSeconds(5),
        //                TimeSpan.FromSeconds(10),
        //                TimeSpan.FromSeconds(15),
        //            });

        //        retry.Execute(() =>
        //        {
        //            context.Database.EnsureDeleted();
        //            context.Database.Migrate();
        //        });
        //        logger.LogInformation($"Migrated database associated with context");
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, $"An error occurred while migrating the database used on context");
        //    }

        //    var applicationInitializer = services.GetService<ApplicationInitializer>();
        //    await applicationInitializer.SeedUsers();
        //}
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
