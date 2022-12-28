using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProductConfigurator.Mailer;
//public class SendgridSender
//{
//    private const string FromDefaultName = "Product Configurator";

//    private readonly string apiKey;
//    private readonly EmailSettings emailSettings;

//    public SendgridSender(IConfiguration configuration, EmailSettings emailSettings)
//    {
//        apiKey = configuration.GetConnectionString("SendgridApiKey");
//        this.emailSettings = emailSettings;
//    }

//    public async Task SendPlainBody(string recipient, string subject, string plainBody)
//    {
//        var message = new SendGridMessage()
//        {
//            From = new EmailAddress(emailSettings.Sender, FromDefaultName),
//            Subject = subject,
//            PlainTextContent = plainBody,
//        };
//        await SendEmail(recipient, message);
//    }

//    public async Task SendHtmlBody(string recipient, string subject, string htmlBody)
//    {
//        var message = new SendGridMessage()
//        {
//            From = new EmailAddress(emailSettings.Sender, FromDefaultName),
//            Subject = subject,
//            HtmlContent = htmlBody,
//        };
//        await SendEmail(recipient, message);
//    }

//    private async Task SendEmail(string recipient, SendGridMessage message)
//    {
//        var client = new SendGridClient(apiKey);
//        message.AddTo(new EmailAddress(recipient));
//        var response = await client.SendEmailAsync(message);
//        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
//        {
//            throw new Exception(await response.Body.ReadAsStringAsync());
//        }
//    }
//}
