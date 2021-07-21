using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ProductConfigurator.FunctionalTests
{
    public class ServerFixture
    {
        public TestServer Server { get; private set; }

        public ServerFixture()
        {
            var host = new HostBuilder()
              .ConfigureWebHost(webBuilder =>
              {
                  webBuilder
                      .UseTestServer()
                      .UseStartup<TestStartup>()
                      .UseContentRoot(Directory.GetCurrentDirectory())
                      .ConfigureAppConfiguration(app =>
                      {
                          app.AddJsonFile("FunctionalTestsSettings.json", optional: true);
                          app.AddUserSecrets(typeof(ServerFixture).Assembly, optional: true);
                          app.AddEnvironmentVariables();
                      });
              })
              .Start();

            Server = host.GetTestServer();
        }

        public T GetService<T>() => (T)Server.Services.GetService(typeof(T));
    }
}
