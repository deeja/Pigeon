namespace Pigeon.Tests
{
    using System.Net.Mail;

    using Pigeon.Adapters;

    public class MailServiceStub: IMailService
    {
        public MailMessage MailMessage { get; private set; }

        public void SendMessage(MailMessage mailMessage)
        {
            this.MailMessage = mailMessage;
        }
    }
}