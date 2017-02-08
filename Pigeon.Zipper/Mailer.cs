namespace Pigeon.Zipper
{
    using System.Linq;
    using System.Net.Mail;

    public class Mailer
    {
        private readonly IMailService mailService;

        public Mailer(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public void SendZip(ZipResult result, string emailAddress, string attachmentName)
        {
            string body = string.Join("\n\r",result.Entries);

            var attachment = new Attachment(result.ZipStream, attachmentName);
            this.mailService.SendMessage(new MailMessage() {To = { emailAddress}, Body = body, Attachments = { attachment}});
        }
    }
}