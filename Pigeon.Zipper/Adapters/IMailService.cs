namespace Pigeon.Zipper.Adapters
{
    using System.Net.Mail;

    public interface IMailService
    {
        void SendMessage(MailMessage mailMessage);
    }
}