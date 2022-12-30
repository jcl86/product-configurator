using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

using ProductConfigurator.FunctionalTests.Scenarios.Administration.Account;
using ProductConfigurator.FunctionalTests.Scenarios.Administration.Users;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Management.Products;

namespace ProductConfigurator.FunctionalTests.Scenarios.Management.Products;

public static class ProductExtensions
{
    public static async Task<SaveProductResponse> ProductInDatabase(this ServerFixture given, int tenantId)
    {
        SaveProductRequest request = ProductMother.Create();

        HttpResponseMessage response = await given.Server
          .CreateRequest(Endpoints.Products.PutSave)
          .ForTenant(tenantId)
          .WithIdentity(Identities.SuperAdministrator)
          .WithJsonBody(request)
          .PutAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        SaveProductResponse? model = await response.ReadJsonResponse<SaveProductResponse>();
        model.Should().NotBeNull();
        return model!;
    }
}

