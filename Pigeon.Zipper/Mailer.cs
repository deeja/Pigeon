namespace Pigeon
{
    using System.Linq;
    using System.Net.Mail;

    using Pigeon.Adapters;

    public class Mailer
    {
        private readonly IMailService mailService;

        public Mailer(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public void SendZip(ZipResult result, string emailAddress, string emailFrom, string subject, string attachmentName)
        {

            string body;

            if (result != null && result.Entries.Any())
            {
                body = string.Join("\n\r", result.Entries);
            }
            else
            {
                body = "No files found for range specified";
            }

            var mailMessage = new MailMessage()
                                  {
                                      To = { emailAddress },
                                      From = new MailAddress(emailFrom),
                                      Body = body,
                                      Subject = subject
                                  };

            if (result?.ZipStream != null)
            {
                mailMessage.Attachments.Add(new Attachment(result.ZipStream, attachmentName));
            }

            this.mailService.SendMessage(mailMessage);
        }
    }
}