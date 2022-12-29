using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Administration.Users;
using ProductConfigurator.Shared;
using FluentAssertions;

namespace ProductConfigurator.FunctionalTests;
public static class UserExtensions
{
    public static async Task<RegisterUserResponse> UserInDatabase(this ServerFixture given, int tenantId, string? password = null)
    {
        RegisterUserRequest request = UserMother.Register(password);

        HttpResponseMessage response = await given.Server
          .CreateRequest(Endpoints.Users.Register)
          .ForTenant(tenantId)
          .WithIdentity(Identities.SuperAdministrator)
          .WithJsonBody(request)
          .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        RegisterUserResponse? model = await response.ReadJsonResponse<RegisterUserResponse>();
        model.Should().NotBeNull();
        return model!;
    }
}
