using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductConfigurator.Host
{
    public class PingRequest
    {
        public string Api { get; set; }
    }
    public class MailchimpClient
    {
        private const string BaseUrl = "https://mandrillapp.com/api/1.0";

        private readonly HttpClient client;
        private readonly string apiKey;

        public MailchimpClient(HttpClient httpClient, string apiKey)
        {
            client = httpClient ?? throw new ArgumentNullException("mailchimp httpclient");
            this.apiKey = apiKey;
        }

        public async Task<string> Ping()
        {
            string url = $"{BaseUrl}/users/ping";
            var request = new PingRequest()
            {
                Api = apiKey
            };
            var response = await client.PostAsJsonAsync("", request);
            await response.re
            var response = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await RefreshToken();
                response = await client.GetAsync(url);
            }

            response.EnsureSuccessStatusCode();
            var result = await response.ReadJsonResponse<TResponse>();
            return result;
        }

        private async Task<string> GetToken()
        {
            if (!inMemoryToken.HasToken)
            {
                inMemoryToken.SetToken(await RequestClientCredentialsTokenAsync());
            }
            return inMemoryToken.BearerToken;
        }
    }
}
