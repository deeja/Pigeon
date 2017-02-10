namespace Pigeon.Zipper
{
    using System.Linq;
    using System.Net.Mail;

    using Pigeon.Zipper.Adapters;

    public class Mailer
    {
        private readonly IMailService mailService;

        public Mailer(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public void SendZip(ZipResult result, string emailAddress, string emailFrom, string subject, string attachmentName)
        {
            string body = string.Join("\n\r", result.Entries);

            var attachment = new Attachment(result.ZipStream, attachmentName);
            var mailMessage = new MailMessage()
                                  {
                                      To = { emailAddress },
                                      From = new MailAddress(emailFrom),
                                      Body = body,
                                      Attachments = { attachment },
                                      Subject = subject
                                  };
            this.mailService.SendMessage(mailMessage);
        }
    }
}