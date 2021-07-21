using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductConfigurator.Api
{
    public class MailchimpClient
    {
        public const string BaseUrl = "https://mandrillapp.com/api/1.0";

        private readonly HttpClient client;
        private readonly string apiKey;

        public MailchimpClient(HttpClient httpClient, string apiKey)
        {
            client = httpClient ?? throw new ArgumentNullException("mailchimp httpclient");
            this.apiKey = apiKey;
        }

        public async Task<string> Ping()
        {
            string url = $"users/ping";
            var request = new PingRequest()
            {
                Api = apiKey
            };
            var response = await client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
