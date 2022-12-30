using Microsoft.AspNetCore.Http;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Account;
using ProductConfigurator.Shared.Modules.Administration.Users;
using ProductConfigurator.FunctionalTests.Scenarios.Administration.Users;

namespace ProductConfigurator.FunctionalTests.Scenarios.Administration.Account;

[Collection(nameof(ServerFixtureCollection))]
public class PaswordChangeShould
{
    private readonly ServerFixture Given;

    public PaswordChangeShould(ServerFixture fixture)
    {
        Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task Success()
    {
        string oldPassword = PasswordMother.Valid();
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant1, oldPassword);

        await Given.SuccessToLogin(user.Email!, oldPassword);

        string newPassword = PasswordMother.Valid();

        HttpResponseMessage response = await Given.Server
         .CreateRequest(Endpoints.Accounts.ChangePassword)
         .ForTenant(Tenants.Tenant1)
         .WithIdentity(Identities.FromUser(user))
         .WithJsonBody(new ChangePasswordRequest()
         {
             CurrentPassword = oldPassword,
             NewPassword = newPassword
         })
         .PutAsync();
        await response.ShouldBe(StatusCodes.Status204NoContent);

        await Given.SuccessToLogin(user.Email!, newPassword);
        await Given.FailToLogin(user.Email!, oldPassword);
    }

    [Fact]
    public async Task Fail_when_password_is_wrong()
    {
        string oldPassword = PasswordMother.Valid();
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant1, oldPassword);

        await Given.SuccessToLogin(user.Email!, oldPassword);

        string wrongPassword = PasswordMother.Valid();

        HttpResponseMessage response = await Given.Server
         .CreateRequest(Endpoints.Accounts.ChangePassword)
         .ForTenant(Tenants.Tenant1)
         .WithIdentity(Identities.FromUser(user))
         .WithJsonBody(new ChangePasswordRequest()
         {
             CurrentPassword = "Any false password",
             NewPassword = wrongPassword
         })
         .PutAsync();
        await response.ShouldBe(StatusCodes.Status400BadRequest);

        await Given.SuccessToLogin(user.Email!, oldPassword);
        await Given.FailToLogin(user.Email!, wrongPassword);

    }
}
