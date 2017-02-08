namespace Pigeon.Zipper
{
    using System.Linq;
    using System.Net.Mail;

    public class Mailer
    {
        private readonly IMailService mailMock;

        public Mailer(IMailService mailMock)
        {
            this.mailMock = mailMock;
        }

        public void SendZip(ZipResult result, string emailAddress)
        {
            string body = string.Join("\n\r",result.Entries);
            mailMock.SendMessage(new MailMessage() {To = { emailAddress}, Body = body});
        }
    }
}