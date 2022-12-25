using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Account;

namespace ProductConfigurator.FunctionalTests;

public static class LoginExtensions
{
    public static async Task SuccessToLogin(this ServerFixture given, string email, string password)
    {
        HttpResponseMessage response = await given
         .Server
         .CreateRequest(Endpoints.Accounts.Login)
         .WithJsonBody(new LoginRequest()
         {
             Email = email,
             Password = password,
         })
         .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        LoginSuccessResponse? result = await response.ReadJsonResponse<LoginSuccessResponse>();
        result.Should().NotBeNull();
        result!.Email.Should().Be(email);
        result!.Token.Should().NotBeEmpty();
    }

    public static async Task FailToLogin(this ServerFixture given, string email, string password)
    {
        HttpResponseMessage response = await given
         .Server
         .CreateRequest(Endpoints.Accounts.Login)
         .WithJsonBody(new LoginRequest()
         {
             Email = email,
             Password = password,
         })
         .PostAsync();

        await response.ShouldBe(StatusCodes.Status401Unauthorized);
        ProblemDetails? result = await response.ReadJsonResponse<ProblemDetails>();
        result.Should().NotBeNull();
        result!.Status.Should().Be(StatusCodes.Status401Unauthorized);
    }
}
