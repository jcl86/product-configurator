using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Polly;

using ProductConfigurator.Core.Database;
using ProductConfigurator.FunctionalTests.Seedwork;

using System.IO;

using Xunit;

namespace ProductConfigurator.FunctionalTests.Seedwork.Fixture;

public class ServerFixture : IDisposable
{
    private readonly IWebHost host;

    public TestServer Server => host.GetTestServer();

    public T GetService<T>() where T : class
    {
        object? service = Server.Services.GetService(typeof(T));
        if (service is not T parsedService)
        {
            throw new InvalidOperationException($"Service {typeof(T).Name} was not found in the service collection.");
        }
        return parsedService;
    }

    public ServerFixture() 
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

        MigrateDbContext();

        host.Start();
    }

    public void Dispose()
    {
        Server.Dispose();
        host?.Dispose();
    }
    
    public void MigrateDbContext()
    {
        using IServiceScope scope = host.Services.CreateScope();

        IServiceProvider services = scope.ServiceProvider;
        ILogger<ApplicationDbContext> logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();
        ApplicationDbContext? context = services.GetService<ApplicationDbContext>();

        if (context is null)
        {
            throw new InvalidOperationException("ApplicationDbContext was not found in the service collection.");
        }

        try
        {
            logger.LogInformation($"Migrating database associated with context");
            
            Polly.Retry.RetryPolicy retry = Policy.Handle<Exception>().WaitAndRetry(new[]
            {
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10),
                        TimeSpan.FromSeconds(15),
                    });

            retry.Execute(() =>
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            });
            logger.LogInformation($"Migrated database associated with context");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"An error occurred while migrating the database used on context");
        }

        ApplicationInitializer? applicationInitializer = services.GetService<ApplicationInitializer>();
        if (applicationInitializer is null)
        {
            throw new Exception("ApplicationInitializer was not found in the service collection.");
        }
        
        applicationInitializer.SeedUsers().Wait();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
