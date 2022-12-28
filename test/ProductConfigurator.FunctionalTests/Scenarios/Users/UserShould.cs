using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

using Xunit;

namespace ProductConfigurator.FunctionalTests.FunctionalTests;

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
        RegisterUserRequest model = UserMother.Register();
        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Users.Register)
          .WithJsonBody(model)
          .WithIdentity(Identities.SuperAdministrator)
          .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        RegisterUserResponse? user = await response.ReadJsonResponse<RegisterUserResponse>();
        user.Should().NotBeNull();
        user!.Id.Should().NotBeEmpty();
        user!.Email.Should().Be(model.Email);
    }

    [Fact]
    public async Task Fail_to_be_registered_when_not_authorized()
    {
        RegisterUserRequest request = UserMother.Register();
        
        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Users.Register)
          .WithJsonBody(request)
          .WithIdentity(Identities.PlainUser)
          .PostAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task Fail_to_be_registered_when_password_is_weak()
    {
        string weakPassword = PasswordMother.Weak();
        
        RegisterUserRequest request = UserMother.Register(weakPassword);
        
        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Users.Register)
          .WithJsonBody(request)
          .WithIdentity(Identities.SuperAdministrator)
          .PostAsync();

        await response.ShouldBe(StatusCodes.Status400BadRequest);
    }

    [Fact]
    public async Task Be_all_found()
    {
        RegisterUserResponse userInDatabase = await Given.UserInDatabase();

        HttpResponseMessage response = await Given
          .Server
          .CreateRequest(Endpoints.Users.GetAll)
          .WithIdentity(Identities.SuperAdministrator)
          .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        ListUserResponse? users = await response.ReadJsonResponse<ListUserResponse>();
        users.Should().NotBeNull();
        users!.Users.Should().ContainEquivalentOf(new ListUserResponse.UserItem()
        {
            Id = userInDatabase.Id,
            Email = userInDatabase.Email!,
            Roles = new string[] { RoleNames.PlainUser }
        });
    }

    [Fact]
    public async Task Fail_to_be_all_found_when_not_authorized()
    {
        HttpResponseMessage response = await Given
            .Server
            .CreateRequest(Endpoints.Users.GetAll)
            .WithIdentity(Identities.PlainUser)
            .GetAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task Be_found()
    {
        RegisterUserResponse user = await Given.UserInDatabase();

        HttpResponseMessage response = await Given.Server
            .CreateRequest(Endpoints.Users.Get(user.Id))
            .WithIdentity(Identities.SuperAdministrator)
            .GetAsync();
        await response.ShouldBe(StatusCodes.Status200OK);
        GetUserResponse? result = await response.ReadJsonResponse<GetUserResponse>();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task Fail_to_be_found_when_does_not_exist()
    {
        string unexistingUserId = Guid.NewGuid().ToString();

        HttpResponseMessage response = await Given.Server
               .CreateRequest(Endpoints.Users.Get(unexistingUserId))
               .WithIdentity(Identities.SuperAdministrator)
               .GetAsync();

        await response.ShouldBe(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Fail_to_be_found_when_not_authorized()
    {
        HttpResponseMessage response = await Given
          .Server
          .CreateRequest(Endpoints.Users.GetAll)
          .WithIdentity(Identities.PlainUser)
          .GetAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task Be_deleted()
    {
        RegisterUserResponse user = await Given.UserInDatabase();

        HttpResponseMessage response = await Given
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

        HttpResponseMessage response = await Given.Server
               .CreateRequest(Endpoints.Users.Delete(unexistingUserId))
               .WithIdentity(Identities.SuperAdministrator)
               .DeleteAsync();

        await response.ShouldBe(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Fail_to_be_deleted_when_not_authorized()
    {
        RegisterUserResponse user = await Given.UserInDatabase();

        HttpResponseMessage response = await Given
         .Server
         .CreateRequest(Endpoints.Users.Delete(user.Id))
         .WithIdentity(Identities.PlainUser)
         .DeleteAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }
}
