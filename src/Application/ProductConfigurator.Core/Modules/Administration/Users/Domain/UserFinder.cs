using Microsoft.EntityFrameworkCore;
using ProductConfigurator.Shared;
using ProductConfigurator.Core.Database;

namespace ProductConfigurator.Core.Modules.Administration.Users;

[Service]
public class UserFinder
{
    private readonly ApplicationDbContext context;

    public UserFinder(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<User> Find(string userId)
    {
        User? user = await context.Users
            .Include(x => x.Claims)
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == userId);

        if (user is null)
        {
            throw new NotFoundException<User>(userId);
        }

        return user;
    }

    public async Task<User> FindByEmail(string email)
    {
        User? user = await context.Users
            .Include(x => x.Claims)
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .SingleOrDefaultAsync(x => x.Email == email);

        if (user is null)
        {
            throw new NotFoundException($"User with email {email} was not found");
        }

        return user;
    }
}
