using System.Threading.Tasks;

namespace SampleOutbox.Application.Configuration.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message);
    }
}