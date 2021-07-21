using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProductConfigurator.Host
{
    public static class HttpClientsConfigurationExtensions
    {
        public static IServiceCollection AddMailchimpHttpClient(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var apiKey = configuration.GetConnectionString("MailchimpApiKey");

            AddHttpClient(services, MailchimpClient.BaseUrl);

            return services;
        }

        private static void AddHttpClient(this IServiceCollection services, string baseUrl)
        {
            services.AddHttpClient<MailchimpClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
