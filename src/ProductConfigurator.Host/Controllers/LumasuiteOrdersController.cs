using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductConfigurator.Host.Controllers
{
    [ApiController]
    [Route("api/lumasuite/orders")]
    public class LumasuiteOrdersController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> PostCreate(CreateOrder dto)
        {
            
        }
    }
}
