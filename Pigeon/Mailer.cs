namespace Pigeon
{
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;

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
            using (mailMessage)
            {
                if (result?.ZipStream != null)
                {
                    result.ZipStream.Position = 0;
                    Attachment attachment = new Attachment(result.ZipStream, attachmentName + ".zip", MediaTypeNames.Application.Zip);
                    mailMessage.Attachments.Add(attachment);
                }

                this.mailService.SendMessage(mailMessage); 
            }
        }
    }
}