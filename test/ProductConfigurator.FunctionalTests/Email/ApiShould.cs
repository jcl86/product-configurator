using FluentAssertions;

using Microsoft.AspNetCore.Http;

using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;

using Xunit;

namespace ProductConfigurator.FunctionalTests;

[Collection(nameof(ServerFixtureCollection))]
public class ApiShould
{
    private readonly ServerFixture given;

    public ApiShould(ServerFixture fixture)
    {
        given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task be_healthy_for_tenant_1()
    {
        HttpResponseMessage response = await given.Server
           .CreateRequest(Endpoints.Health)
           .ForTenant(Tenants.Tenant1)
           .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);

        string result = await response.Content.ReadAsStringAsync();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task be_healthy_for_tenant_2()
    {
        HttpResponseMessage response = await given.Server
           .CreateRequest(Endpoints.Health)
           .ForTenant(Tenants.Tenant2)
           .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);

        string result = await response.Content.ReadAsStringAsync();
        result.Should().BeEmpty();
    }
}
