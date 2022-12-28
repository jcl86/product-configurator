using System.Threading.Tasks;

namespace ProductConfigurator.Domain
{
    public interface ISendgridEmailSender
    {
        Task SendHtmlBody(string recipient, string subject, string htmlBody);
        Task SendPlainBody(string recipient, string subject, string plainBody);
    }
}
