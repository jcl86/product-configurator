using SuperErp.Core.FunctionalTests;
using SuperErp.Management.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

namespace ProductConfigurator.FunctionalTests.FunctionalTests
{

    [Collection(nameof(ServerFixtureCollection))]
    public class UserShould
    {
        private readonly ServerFixture Given;

        public UserShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_registered()
        {
            var model = UserMother.Register();
            var response = await Given.Server
              .CreateRequest(Endpoints.Users.Register)
              .WithJsonBody(model)
              .WithIdentity(Identities.SuperAdministrator)
              .PostAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var user = await response.ReadJsonResponse<User>();
            user.Email.Should().Be(model.Email);
            user.StartDate.Should().Be(model.StartDate);
            user.DelegationId.Should().Be(model.DelegationId);
            user.Roles.Should().BeEquivalentTo(new[] { RoleNames.PlainUser });
            user.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Fail_to_be_registered_when_not_authorized()
        {
            var model = UserMother.Register();
            var response = await Given.Server
              .CreateRequest(Endpoints.Users.Register)
              .WithJsonBody(model)
              .WithIdentity(Identities.PlainUser)
              .PostAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }

        [Fact]
        public async Task Fail_to_be_registered_when_password_is_weak()
        {
            var weakPassword = PasswordMother.Weak();
            var model = UserMother.Register(weakPassword);
            var response = await Given.Server
              .CreateRequest(Endpoints.Users.Register)
              .WithJsonBody(model)
              .WithIdentity(Identities.SuperAdministrator)
              .PostAsync();

            await response.ShouldBe(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Be_all_found()
        {
            var created = await Given.UserInDatabase();

            var response = await Given
              .Server
              .CreateRequest(Endpoints.Users.GetAll)
              .WithIdentity(Identities.SuperAdministrator)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var users = await response.ReadJsonResponse<IEnumerable<User>>();
            users.Should().ContainEquivalentOf(created);
        }

        [Fact]
        public async Task Fail_to_be_all_found_when_not_authorized()
        {
            var response = await Given
              .Server
              .CreateRequest(Endpoints.Users.GetAll)
              .WithIdentity(Identities.PlainUser)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }

        [Fact]
        public async Task Be_found()
        {
            var user = await Given.UserInDatabase();

            var response = await Given.Server
             .CreateRequest(Endpoints.Users.Get(user.Id))
             .WithIdentity(Identities.SuperAdministrator)
             .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);
            var result = await response.ReadJsonResponse<User>();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task Fail_to_be_found_when_does_not_exist()
        {
            string unexistingUserId = Guid.NewGuid().ToString();

            var response = await Given.Server
                   .CreateRequest(Endpoints.Users.Get(unexistingUserId))
                   .WithIdentity(Identities.SuperAdministrator)
                   .GetAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }


        [Fact]
        public async Task Fail_to_be_found_when_not_authorized()
        {
            var response = await Given
              .Server
              .CreateRequest(Endpoints.Users.GetAll)
              .WithIdentity(Identities.PlainUser)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }

        [Fact]
        public async Task Be_deleted()
        {
            var user = await Given.UserInDatabase();

            var response = await Given
             .Server
             .CreateRequest(Endpoints.Users.Delete(user.Id))
             .WithIdentity(Identities.SuperAdministrator)
             .DeleteAsync();

            await response.ShouldBe(StatusCodes.Status204NoContent);

            response = await Given.Server
                   .CreateRequest(Endpoints.Users.Get(user.Id))
                   .WithIdentity(Identities.SuperAdministrator)
                   .GetAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Fail_to_be_deleted_when_does_not_exist()
        {
            string unexistingUserId = Guid.NewGuid().ToString();

            var response = await Given.Server
                   .CreateRequest(Endpoints.Users.Delete(unexistingUserId))
                   .WithIdentity(Identities.SuperAdministrator)
                   .DeleteAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Fail_to_be_deleted_when_not_authorized()
        {
            var user = await Given.UserInDatabase();

            var response = await Given
             .Server
             .CreateRequest(Endpoints.Users.Delete(user.Id))
             .WithIdentity(Identities.PlainUser)
             .DeleteAsync();

            await response.ShouldBe(StatusCodes.Status403Forbidden);
        }
    }
}
