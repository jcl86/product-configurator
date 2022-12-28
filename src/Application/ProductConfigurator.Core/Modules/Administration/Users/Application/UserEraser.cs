using Microsoft.AspNetCore.Identity;

using ProductConfigurator.Shared;

namespace ProductConfigurator.Core.Modules.Administration.Users;

[Service]
    public class UserEraser
    {
        private readonly UserManager<User> userManager;
        private readonly UserFinder userFinder;

        public UserEraser(UserManager<User> userManager, UserFinder userFinder)
        {
            this.userManager = userManager;
            this.userFinder = userFinder;
        }

        public async Task Delete(string userId)
        {
            User user = await userFinder.Find(userId);
            await userManager.DeleteAsync(user);
        }
    }

