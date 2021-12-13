using System.Threading.Tasks;

namespace CareerSite.MvcWebUI.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
