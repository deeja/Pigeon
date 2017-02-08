namespace Pigeon.Zipper.Adapters
{
    using System.Net.Mail;

    using Sitecore;

    public class MailService: IMailService
    {
        public void SendMessage(MailMessage mailMessage)
        {
            MainUtil.SendMailAsync(mailMessage);
        }
    }
}