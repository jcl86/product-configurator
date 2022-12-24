using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProductConfigurator.Shared.Modules.Administration.Account;

namespace ProductConfigurator.FunctionalTests;

public static class LoginExtensions
{
    public static async Task SuccessToLogin(this ServerFixture given, string email, string password)
    {
        var response = await given
         .Server
         .CreateRequest(Model.Endpoints.Accounts.Login)
         .WithJsonBody(new LoginRequest()
         {
             Email = email,
             Password = password,
         })
         .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        var result = await response.ReadJsonResponse<LoginSuccessResponse>();
        result.Username.Should().Be(email);
        result.Token.Should().NotBeEmpty();
    }

    public static async Task FailToLogin(this ServerFixture given, string email, string password)
    {
        var response = await given
         .Server
         .CreateRequest(Model.Endpoints.Accounts.Login)
         .WithJsonBody(new LoginRequest()
         {
             Email = email,
             Password = password,
         })
         .PostAsync();

        await response.ShouldBe(StatusCodes.Status401Unauthorized);
        var result = await response.ReadJsonResponse<ProblemDetails>();
        result.Status.Should().Be(StatusCodes.Status401Unauthorized);
    }
}
