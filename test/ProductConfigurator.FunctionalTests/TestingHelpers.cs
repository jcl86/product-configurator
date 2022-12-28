using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace ProductConfigurator.FunctionalTests;

public static class TestingHelpers
{
    public static async Task<TModel?> ReadJsonResponse<TModel>(this HttpResponseMessage response)
    {
        string json = await response.Content.ReadAsStringAsync();
        return json.Deserialize<TModel>();
    }

    public static async Task ShouldBe(this HttpResponseMessage response, int statusCode)
    {
        response.StatusCode.Should().Be((HttpStatusCode)statusCode, await response.Content.ReadAsStringAsync());
    }
}
