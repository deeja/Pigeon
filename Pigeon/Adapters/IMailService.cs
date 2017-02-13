namespace Pigeon.Adapters
{
    using System.Net.Mail;

    public interface IMailService
    {
        void SendMessage(MailMessage mailMessage);
    }
}