using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductConfigurator.Host.Controllers
{
    [ApiController]
    [Route("api/mail")]
    public class MailController : ControllerBase
    {
        private readonly MailchimpClient mailchimpClient;

        public MailController(MailchimpClient mailchimpClient)
        {
            this.mailchimpClient = mailchimpClient;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Ping()
        {
            var result = await mailchimpClient.Ping();
            return result;
        }
    }

}
