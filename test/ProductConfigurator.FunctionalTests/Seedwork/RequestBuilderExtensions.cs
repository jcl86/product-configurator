using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

using Newtonsoft.Json;

using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductConfigurator.FunctionalTests;


public static class RequestBuilderExtensions
{
    public static Task<HttpResponseMessage> PutAsync(this RequestBuilder requestBuilder)
    {
        return requestBuilder.SendAsync(HttpMethods.Put);
    }

    public static Task<HttpResponseMessage> PatchAsync(this RequestBuilder requestBuilder)
    {
        return requestBuilder.SendAsync(HttpMethods.Patch);
    }

    public static Task<HttpResponseMessage> DeleteAsync(this RequestBuilder requestBuilder)
    {
        return requestBuilder.SendAsync(HttpMethods.Delete);
    }

    public static RequestBuilder WithJsonBody<TModel>(this RequestBuilder builder, TModel content, string contentType = "application/json")
    {
        string json = content.Serialize();
        return builder.And(message => message.Content = new StringContent(json, Encoding.UTF8, contentType));
    }

    public static RequestBuilder ForTenant(this RequestBuilder builder, int tenantId)
    {
        return builder.And(message => message.Headers.Add("Tenant", tenantId.ToString()));
    }
}
