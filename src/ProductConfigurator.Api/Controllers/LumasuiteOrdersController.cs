using Microsoft.AspNetCore.Mvc;
using ProductConfigurator.Domain;
using ProductConfigurator.Shared;
using System.Threading.Tasks;

namespace ProductConfigurator.Api
{
    [ApiController]
    [Route("api/lumasuite/orders")]
    public class LumasuiteOrdersController : ControllerBase
    {
        private readonly EmailSender emailSender;

        public LumasuiteOrdersController(EmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(OrderRequest dto)
        {
            await emailSender.Send(dto);
            return Ok();
        }
    }

}
