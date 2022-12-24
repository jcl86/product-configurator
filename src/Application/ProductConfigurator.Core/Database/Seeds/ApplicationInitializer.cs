//using SuperErp.Management.Domain;
//using SuperErp.Core;
//using Microsoft.AspNetCore.Identity;

//namespace SuperErp.Data
//{
//    [Service]
//    public class ApplicationInitializer
//    {
//        private readonly UserManager<User> userManager;
//        private readonly RoleManager<Role> roleManager;
//        private readonly UserSettings userSettings;

//        public ApplicationInitializer(UserManager<User> userManager, 
//            RoleManager<Role> roleManager, 
//            UserSettings userSettings)
//        {
//            this.userManager = userManager;
//            this.roleManager = roleManager;
//            this.userSettings = userSettings;
//        }

//        public async Task SeedUsers()
//        {
//            await CreateRole(Management.Model.RoleNames.SuperAdministrator);
//            await CreateRole(Management.Model.RoleNames.Manager);
//            await CreateRole(Management.Model.RoleNames.PlainUser);

//            if (userSettings is null || userSettings.DefaultAdministrator is null || userSettings.DefaultAdministrator.Username.IsEmpty())
//            {
//                throw new DomainException("Default administrator must have a value");
//            }

//            if ((await userManager.FindByEmailAsync(userSettings.DefaultAdministrator.Username)) is null)
//            {
//                var user = new User
//                {
//                    UserName = userSettings.DefaultAdministrator.Username,
//                    Email = userSettings.DefaultAdministrator.Username
//                };

//                var result = await userManager.CreateAsync(user, userSettings.DefaultAdministrator.Password);

//                if (result.Succeeded)
//                {
//                    await userManager.AddToRoleAsync(user, Management.Model.RoleNames.SuperAdministrator);
//                }
//            }
//        }

//        public async Task CreateRole(string roleName)
//        {
//            if ((await roleManager.FindByNameAsync(roleName)) is null)
//            {
//                await roleManager.CreateAsync(new Role(roleName));
//            }
//        }
//    }
//}
