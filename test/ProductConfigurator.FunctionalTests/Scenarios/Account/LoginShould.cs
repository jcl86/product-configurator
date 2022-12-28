using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Account;
using ProductConfigurator.Shared.Modules.Administration.Users;

using Xunit;

namespace ProductConfigurator.FunctionalTests.FunctionalTests;

[Collection(nameof(ServerFixtureCollection))]
public class LoginShould
{
    private readonly ServerFixture Given;

    public LoginShould(ServerFixture fixture)
    {
        Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task Success()
    {
        string password = PasswordMother.Valid();
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant1, password);

        HttpResponseMessage response = await Given.Server
         .CreateRequest(Endpoints.Accounts.Login)
         .WithJsonBody(new LoginRequest()
         {
             Email = user.Email!,
             Password = password,
         })
        .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        LoginSuccessResponse? result = await response.ReadJsonResponse<LoginSuccessResponse>();
        result.Should().NotBeNull();
        result!.Email!.Should().Be(user.Email);
        result!.Token.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Fail_when_password_is_wrong()
    {
        string password = PasswordMother.Valid();
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given.Server
         .CreateRequest(Endpoints.Accounts.Login)
         .WithJsonBody(new LoginRequest()
         {
             Email = user.Email!,
             Password = password,
         })
        .PostAsync();

        await response.ShouldBe(StatusCodes.Status401Unauthorized);
        ProblemDetails? result = await response.ReadJsonResponse<ProblemDetails>();
        result.Should().NotBeNull();
        result!.Status.Should().Be(StatusCodes.Status401Unauthorized);
    }
}
