using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductConfigurator.Api
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

        [HttpGet, Route("ping")]
        public async Task<ActionResult<string>> Ping()
        {
            var result = await mailchimpClient.Ping();
            return result;
        }
    }

}
