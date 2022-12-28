using Microsoft.AspNetCore.Identity;

using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration.Users;

[Service]
public class UserRegister
{
    private readonly UserManager<User> userManager;
    private readonly UserFinder userFinder;

    public UserRegister(UserManager<User> userManager, UserFinder userFinder)
    {
        this.userManager = userManager;
        this.userFinder = userFinder;
    }

    public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
    {
        EmailAddress emailAddress = new(request.Email);

        User user = new(emailAddress);

        IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            IEnumerable<string> errors = result.Errors.Select(x => x.Description);
            throw new DomainException($"User {user} could not be created. {string.Join(", ", errors)}");
        }

        await userManager.AddToRoleAsync(user, RoleNames.PlainUser);

        User searched = await userFinder.Find(user.Id);

        return new RegisterUserResponse()
        {
            Id = searched.Id,
            Email = searched.Email!,
            Roles = searched.RoleNames
        };
    }

}
