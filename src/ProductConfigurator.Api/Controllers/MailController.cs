using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductConfigurator.Api
{
    [ApiController]
    [Route("api/mail")]
    public class MailController : ControllerBase
    {
        [HttpGet, Route("ping")]
        public ActionResult<string> Ping()
        {
            return Ok("Pong");
        }       
    }

}
