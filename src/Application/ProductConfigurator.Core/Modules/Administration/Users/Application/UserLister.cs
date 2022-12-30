using Microsoft.EntityFrameworkCore;

using ProductConfigurator.Core.Database;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration.Users;

[Service]
public class UserLister
{
    private readonly ApplicationContext context;

    public UserLister(ApplicationContext context)
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

        return new ListUserResponse()
        {
            Users = users.Select(x => new ListUserResponse.UserItem()
            {
                Id = x.Id,
                Email = x.Email!,
                Roles = x.RoleNames,
                TenantId = x.ShopId
            })
        };
    }
}