using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Management.Products;

using Xunit;

namespace ProductConfigurator.FunctionalTests.Scenarios.Management.Products;

[Collection(nameof(ServerFixtureCollection))]
public class ProductShould
{
    private readonly ServerFixture Given;

    public ProductShould(ServerFixture fixture)
    {
        Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task Be_created_by_admin()
    {
        SaveProductRequest request = ProductMother.Create();

        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Products.PutSave)
          .ForTenant(Tenants.Tenant1)
          .WithIdentity(Identities.SuperAdministrator)
          .WithJsonBody(request)
          .PutAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        SaveProductResponse? model = await response.ReadJsonResponse<SaveProductResponse>();
        model.Should().NotBeNull();
        model!.Id.Should().BeGreaterThan(0);
        model!.Name.Should().Be(request.Name);
    }

    [Fact]
    public async Task Be_created_in_the_same_tenant()
    {
        SaveProductRequest request = ProductMother.Create();

        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Products.PutSave)
          .ForTenant(Tenants.Tenant1)
          .WithIdentity(Identities.FromTenant(Tenants.Tenant1))
          .WithJsonBody(request)
          .PutAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        SaveProductResponse? model = await response.ReadJsonResponse<SaveProductResponse>();
        model.Should().NotBeNull();
        model!.Id.Should().BeGreaterThan(0);
        model!.Name.Should().Be(request.Name);
    }

    [Fact]
    public async Task Fail_to_be_created_on_different_tenant()
    {
        SaveProductRequest request = ProductMother.Create();

        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Products.PutSave)
          .ForTenant(Tenants.Tenant2)
          .WithIdentity(Identities.FromTenant(Tenants.Tenant1))
          .WithJsonBody(request)
          .PutAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }
}

