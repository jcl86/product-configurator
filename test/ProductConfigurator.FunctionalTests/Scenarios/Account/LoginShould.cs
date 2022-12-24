using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperErp.Core.FunctionalTests;
using SuperErp.Management.Model;

namespace ProductConfigurator.FunctionalTests.FunctionalTests
{
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
            var user = await Given.UserInDatabase(password);

            var response = await Given.Server
             .CreateRequest(Endpoints.Accounts.Login)
             .WithJsonBody(new LoginRequest()
             {
                 Email = user.Email,
                 Password = password,
             })
            .PostAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var result = await response.ReadJsonResponse<AuthenticationSuccessResponse>();
            result.Username.Should().Be(user.Email);
            result.Token.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Fail_when_password_is_wrong()
        {
            string password = PasswordMother.Valid();
            var user = await Given.UserInDatabase();

            var response = await Given.Server
             .CreateRequest(Endpoints.Accounts.Login)
             .WithJsonBody(new LoginRequest()
             {
                 Email = user.Email,
                 Password = password,
             })
            .PostAsync();

            await response.ShouldBe(StatusCodes.Status401Unauthorized);
            var result = await response.ReadJsonResponse<ProblemDetails>();
            result.Status.Should().Be(StatusCodes.Status401Unauthorized);
        }
    }
}
