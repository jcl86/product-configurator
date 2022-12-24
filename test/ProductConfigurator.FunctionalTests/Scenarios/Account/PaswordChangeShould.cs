using SuperErp.Core.FunctionalTests;
using Microsoft.AspNetCore.Http;
using Xunit;
using SuperErp.Management.Model;
using Microsoft.AspNetCore.TestHost;

namespace ProductConfigurator.FunctionalTests
{
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
            var user = await Given.UserInDatabase(oldPassword);

            await Given.SuccessToLogin(user.Email, oldPassword);

            string newPassword = PasswordMother.Valid();

            var response = await Given
             .Server
             .CreateRequest(Endpoints.Accounts.ChangePassword)
             .WithIdentity(Identities.FromUser(user))
             .WithJsonBody(new ChangePasswordRequest()
             {
                 CurrentPassword = oldPassword,
                 NewPassword = newPassword
             })
             .PutAsync();
            await response.ShouldBe(StatusCodes.Status204NoContent);

            await Given.SuccessToLogin(user.Email, newPassword);
            await Given.FailToLogin(user.Email, oldPassword);
        }

        [Fact]
        public async Task Fail_when_password_is_wrong()
        {
            string oldPassword = PasswordMother.Valid();
            var user = await Given.UserInDatabase(oldPassword);

            await Given.SuccessToLogin(user.Email, oldPassword);

            string wrongPassword = PasswordMother.Valid();

            var response = await Given
             .Server
             .CreateRequest(Endpoints.Accounts.ChangePassword)
             .WithIdentity(Identities.FromUser(user))
             .WithJsonBody(new ChangePasswordRequest()
             {
                 CurrentPassword = "Any false password",
                 NewPassword = wrongPassword
             })
             .PutAsync();
            await response.ShouldBe(StatusCodes.Status400BadRequest);

            await Given.SuccessToLogin(user.Email, oldPassword);
            await Given.FailToLogin(user.Email, wrongPassword);

        }
    }
}
