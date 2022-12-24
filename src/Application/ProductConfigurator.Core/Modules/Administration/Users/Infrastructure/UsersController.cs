using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProductConfigurator.Core.Authorization;
using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration;

[ApiController]
[Route("api/users")]
[Authorize(Policies.IsSuperAdministrator)]
public class UsersController : ControllerBase
{
    private readonly UserLister userLister;
    private readonly UserGetter userGetter;
    private readonly UserEraser userEraser;
    private readonly UserRegister userRegister;

    public UsersController(
        UserLister userLister,
        UserGetter userGetter,
        UserEraser userEraser, 
        UserRegister userRegister)
    {
        this.userLister = userLister;
        this.userGetter = userGetter;
        this.userEraser = userEraser;
        this.userRegister = userRegister;
    }

    [HttpGet]
    public async Task<ListUserResponse> List() => await userLister.GetAll();

    [HttpGet("{userId}")]
    public async Task<GetUserResponse> GetById(string userId) => await userGetter.Get(userId);

    [HttpPost("register")]
    public async Task<RegisterUserResponse> Register(RegisterUserRequest request) => await userRegister.Register(request);

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(string userId)
    {
        await userEraser.Delete(userId);
        return NoContent();
    }
}
