using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ProductConfigurator.Shared;
using ProductConfigurator.Core.Authorization;
using ProductConfigurator.Core.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration.Account;

[Service]
public class PasswordChanger
{
    private readonly UserManager<User> userManager;

    public PasswordChanger(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task Change(ClaimsPrincipal currentUser, string currentPassword, string newPassword)
    {
        string? userId = currentUser.GetUserId();
        if (userId is null)
        {
            throw new DomainException("User is not authenticated");
        }

        User? user = await userManager.FindByIdAsync(userId);

        if (user is null)
        {
            throw new NotFoundException<User>(userId);
        }

        if (!await userManager.CheckPasswordAsync(user, currentPassword))
        {
            throw new DomainException("Incorrect password");
        }

        IdentityResult result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (!result.Succeeded)
        {
            throw new DomainException(result.Errors.Select(x => x.Description).ToArray());
        }

    }
}
