using Microsoft.EntityFrameworkCore;

using ProductConfigurator.Core.Database;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration.Users;

[Service]
public class UserLister
{
    private readonly ApplicationDbContext context;

    public UserLister(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<ListUserResponse> GetAll()
    {
        List<User> users = await context.Set<User>()
            .Include(x => x.Claims)
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .ToListAsync();

        IEnumerable<ListUserResponse.UserItem> result = users.Select(x => new ListUserResponse.UserItem(id: x.Id, email: x.Email ?? "", roles: x.RoleNames));
        return new ListUserResponse(result);
    }
}