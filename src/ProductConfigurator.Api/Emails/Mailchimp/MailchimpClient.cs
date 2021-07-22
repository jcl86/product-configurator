using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductConfigurator.Api
{
    public class MailchimpClient
    {
        public const string BaseUrl = "https://mandrillapp.com/api/1.0/";

        private readonly HttpClient client;
        private readonly string apiKey;

        public MailchimpClient(HttpClient httpClient, IConfiguration configuration)
        {
            client = httpClient ?? throw new ArgumentNullException("mailchimp httpclient");
            apiKey = configuration.GetConnectionString("MailchimpApiKey");
        }

        public async Task<string> Ping()
        {
            string url = $"users/ping";
            var request = new PingRequest()
            {
                Key = apiKey
            };
            var response = await client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
