using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProductConfigurator.Core.Authorization;
using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration;

[Authorize]
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public async Task<ListUserResponse> List(UserLister userLister) => await userLister.GetAll();
    

    [HttpGet("{userId}")]
    public async Task<GetUserResponse> GetById(UserGetter userGetter, string userId) => await userGetter.Get(userId);
    

    [HttpPost("register")]
    public async Task<RegisterUserResponse> Register(UserRegister userRegister, RegisterUserRequest request) => await userRegister.Register(request);
    

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(UserEraser userEraser, string userId)
    {
        await userEraser.Delete(userId);
        return NoContent();
    }
}
