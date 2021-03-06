using ProductConfigurator.Shared;
using System.Threading.Tasks;

namespace ProductConfigurator.Domain
{
    [Service]
    public class EmailSender
    {
        private readonly ISendgridEmailSender sendgridEmailSender;
        private readonly EmailSettings settings;

        public EmailSender(ISendgridEmailSender sendgridEmailSender, EmailSettings settings)
        {
            this.sendgridEmailSender = sendgridEmailSender;
            this.settings = settings;
        }

        public async Task Send(OrderRequest dto)
        {
            string subject = $"{dto.Name ?? ""} ({dto.Email ?? ""}) request in Product Configurator";
            await sendgridEmailSender.SendPlainBody(settings.LumasuiteReceiver, subject, dto.Body);
        }
    }
}
