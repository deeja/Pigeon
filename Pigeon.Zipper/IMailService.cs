namespace Pigeon.Zipper
{
    using System.Net.Mail;

    public interface IMailService
    {
        void SendMessage(MailMessage mailMessage);
    }
}