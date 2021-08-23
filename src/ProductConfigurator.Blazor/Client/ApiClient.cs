using System.Collections.Generic;
using System.Net.Http;

namespace ProductConfigurator.Blazor
{
    public class ApiClient
    {
        public HttpClient Client { get; }

        public ApiClient(HttpClient client)
        {
            Client = client;
        }
    }
}
