using Microsoft.AspNetCore.Identity;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Database;

[Service]
public class ApplicationInitializer
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;
    private readonly UserSettings userSettings;

    public ApplicationInitializer(UserManager<User> userManager,
        RoleManager<Role> roleManager,
        UserSettings userSettings)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.userSettings = userSettings;
    }

    public async Task SeedUsers()
    {
        await CreateRole(RoleNames.SuperAdministrator);
        await CreateRole(RoleNames.PlainUser);

        if (userSettings is null || userSettings.DefaultAdministrator is null
            || string.IsNullOrWhiteSpace(userSettings.DefaultAdministrator.Username)
            || string.IsNullOrWhiteSpace(userSettings.DefaultAdministrator.Password))
        {
            throw new DomainException("Default administrator must have a value");
        }

        if ((await userManager.FindByEmailAsync(userSettings.DefaultAdministrator.Username)) is null)
        {
            EmailAddress email = new(userSettings.DefaultAdministrator.Username);
            User user = new(email);

            IdentityResult result = await userManager.CreateAsync(user, userSettings.DefaultAdministrator.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RoleNames.SuperAdministrator);
            }
        }
    }

    public async Task CreateRole(string roleName)
    {
        if ((await roleManager.FindByNameAsync(roleName)) is null)
        {
            await roleManager.CreateAsync(new Role(roleName));
        }
    }
}
