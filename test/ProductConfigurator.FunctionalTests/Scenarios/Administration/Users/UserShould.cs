using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.FunctionalTests.Scenarios.Administration.Account;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

using Xunit;

namespace ProductConfigurator.FunctionalTests.Scenarios.Administration.Users;

[Collection(nameof(ServerFixtureCollection))]
public class UserShould
{
    private readonly ServerFixture Given;

    public UserShould(ServerFixture fixture)
    {
        Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task Be_registered_by_admin()
    {
        RegisterUserRequest model = UserMother.Register();
        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Users.Register)
          .ForTenant(Tenants.Tenant1)
          .WithJsonBody(model)
          .WithIdentity(Identities.SuperAdministrator)
          .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        RegisterUserResponse? user = await response.ReadJsonResponse<RegisterUserResponse>();
        user.Should().NotBeNull();
        user!.Id.Should().NotBeEmpty();
        user!.Email.Should().Be(model.Email);
        user!.TenantId.Should().Be(Tenants.Tenant1);
    }

    [Fact]
    public async Task Be_registered_in_the_same_tenant()
    {
        RegisterUserRequest model = UserMother.Register();
        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Users.Register)
          .ForTenant(Tenants.Tenant1)
          .WithJsonBody(model)
          .WithIdentity(Identities.FromTenant(Tenants.Tenant1))
          .PostAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        RegisterUserResponse? user = await response.ReadJsonResponse<RegisterUserResponse>();
        user.Should().NotBeNull();
        user!.Id.Should().NotBeEmpty();
        user!.Email.Should().Be(model.Email);
        user!.TenantId.Should().Be(Tenants.Tenant1);
    }

    [Fact]
    public async Task Fail_to_be_registered_in_other_tenant()
    {
        RegisterUserRequest model = UserMother.Register();
        HttpResponseMessage response = await Given.Server
          .CreateRequest(Endpoints.Users.Register)
          .ForTenant(Tenants.Tenant1)
          .WithJsonBody(model)
          .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
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
    public async Task Be_all_found_by_admin()
    {
        RegisterUserResponse tenant1User = await Given.UserInDatabase(Tenants.Tenant1);
        RegisterUserResponse tenant2User = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given
          .Server
          .CreateRequest(Endpoints.Users.GetAll)
          .ForTenant(Tenants.Tenant1)
          .WithIdentity(Identities.SuperAdministrator)
          .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        ListUserResponse? users = await response.ReadJsonResponse<ListUserResponse>();
        users.Should().NotBeNull();
        users!.Users.Should().ContainEquivalentOf(new ListUserResponse.UserItem()
        {
            Id = tenant1User.Id,
            Email = tenant1User.Email!,
            Roles = new string[] { RoleNames.PlainUser },
            TenantId = tenant1User.TenantId
        });

        users!.Users.Should().NotContain(x => x.Id == tenant2User.Id);
    }

    [Fact]
    public async Task Fail_to_be_all_found_when_not_authorized()
    {
        HttpResponseMessage response = await Given
            .Server
            .CreateRequest(Endpoints.Users.GetAll)
            .ForTenant(Tenants.Tenant1)
            .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
            .GetAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task Be_all_found_for_the_same_tenant()
    {
        RegisterUserResponse tenant1User = await Given.UserInDatabase(Tenants.Tenant1);
        RegisterUserResponse tenant2User = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given
          .Server
          .CreateRequest(Endpoints.Users.GetAll)
          .ForTenant(Tenants.Tenant1)
          .WithIdentity(Identities.FromTenant(Tenants.Tenant1))
          .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
        ListUserResponse? users = await response.ReadJsonResponse<ListUserResponse>();
        users.Should().NotBeNull();
        users!.Users.Should().ContainEquivalentOf(new ListUserResponse.UserItem()
        {
            Id = tenant1User.Id,
            Email = tenant1User.Email!,
            Roles = new string[] { RoleNames.PlainUser },
            TenantId = tenant1User.TenantId
        });

        users!.Users.Should().NotContain(x => x.Id == tenant2User.Id);
    }

    [Fact]
    public async Task Be_found_by_admin()
    {
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given.Server
            .CreateRequest(Endpoints.Users.Get(user.Id))
            .ForTenant(Tenants.Tenant2)
            .WithIdentity(Identities.SuperAdministrator)
            .GetAsync();
        await response.ShouldBe(StatusCodes.Status200OK);
        GetUserResponse? result = await response.ReadJsonResponse<GetUserResponse>();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task Be_found_for_same_tenant()
    {
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given.Server
            .CreateRequest(Endpoints.Users.Get(user.Id))
            .ForTenant(Tenants.Tenant2)
            .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
            .GetAsync();
        await response.ShouldBe(StatusCodes.Status200OK);
        GetUserResponse? result = await response.ReadJsonResponse<GetUserResponse>();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task Fail_to_be_found_in_other_tenant()
    {
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given.Server
            .CreateRequest(Endpoints.Users.Get(user.Id))
            .ForTenant(Tenants.Tenant1)
            .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
            .GetAsync();
        await response.ShouldBe(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task Fail_to_be_found_when_does_not_exist()
    {
        string unexistingUserId = Guid.NewGuid().ToString();

        HttpResponseMessage response = await Given.Server
               .CreateRequest(Endpoints.Users.Get(unexistingUserId))
               .ForTenant(Tenants.Tenant2)
               .WithIdentity(Identities.SuperAdministrator)
               .GetAsync();

        await response.ShouldBe(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Be_deleted_by_admin()
    {
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given
         .Server
         .CreateRequest(Endpoints.Users.Delete(user.Id))
         .ForTenant(Tenants.Tenant2)
         .WithIdentity(Identities.SuperAdministrator)
         .DeleteAsync();

        await response.ShouldBe(StatusCodes.Status204NoContent);

        response = await Given.Server
               .CreateRequest(Endpoints.Users.Get(user.Id))
               .ForTenant(Tenants.Tenant2)
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
               .ForTenant(Tenants.Tenant2)
               .WithIdentity(Identities.SuperAdministrator)
               .DeleteAsync();

        await response.ShouldBe(StatusCodes.Status404NotFound);
    }


    [Fact]
    public async Task Be_deleted_for_same_tenant()
    {
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given
         .Server
         .CreateRequest(Endpoints.Users.Delete(user.Id))
         .ForTenant(Tenants.Tenant2)
         .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
         .DeleteAsync();

        await response.ShouldBe(StatusCodes.Status204NoContent);

        response = await Given.Server
               .CreateRequest(Endpoints.Users.Get(user.Id))
               .ForTenant(Tenants.Tenant2)
               .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
               .GetAsync();

        await response.ShouldBe(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Fail_to_be_deleted_in_other_tenant()
    {
        RegisterUserResponse user = await Given.UserInDatabase(Tenants.Tenant2);

        HttpResponseMessage response = await Given
         .Server
         .CreateRequest(Endpoints.Users.Delete(user.Id))
         .ForTenant(Tenants.Tenant2)
         .WithIdentity(Identities.FromTenant(Tenants.Tenant1))
         .DeleteAsync();

        await response.ShouldBe(StatusCodes.Status403Forbidden);

        response = await Given.Server
               .CreateRequest(Endpoints.Users.Get(user.Id))
               .ForTenant(Tenants.Tenant2)
               .WithIdentity(Identities.FromTenant(Tenants.Tenant2))
               .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);
    }
}
