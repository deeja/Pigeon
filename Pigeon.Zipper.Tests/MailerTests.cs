namespace Pigeon.Zipper.Tests
{
    using System.IO;
    using System.Linq;
    using System.Net.Mail;

    using Moq;

    using NUnit.Framework;

    using Pigeon.Zipper.Adapters;

    [TestFixture]
    public class MailerTests
    {
        private static readonly string emailAddress = "testaddress@something.com";

        private string attachmentName = "this is the attachment.zip";

        [Test]
        public void SendMail_MailMessageSent()
        {
            Mock<IMailService> mailMock = new Mock<IMailService>();
            Mailer mailer = new Mailer(mailMock.Object);
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = new MemoryStream()
            };
            string emailAddress = "testaddress@something.com";
            string subject = "This is the subject";
            mailer.SendZip(result, emailAddress, emailAddress, subject, this.attachmentName);
            mailMock.Verify(service => service.SendMessage(It.IsAny<MailMessage>()));
        }

        [Test]
        public void SendMail_MailMessageCorrectEmailTo()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = new MemoryStream()
            };
            string emailAddressto = "testaddressto@something.com";
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddressto, emailAddress, subject, this.attachmentName);
            Assert.AreEqual(emailAddressto, mailService.MailMessage.To.First().Address);
        }

        [Test]
        public void SendMail_MailMessageCorrectEmailFrom()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = new MemoryStream()
            };
            string emailTo = "testaddressto@something.com";
            string emailFrom = "testaddressfrom@something.com";
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddress, emailFrom, subject, this.attachmentName);
            Assert.AreEqual(emailFrom, mailService.MailMessage.From.Address);
        }


        [Test]
        public void SendMail_MailMessageMessageBodySet()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            var thisisoneTxt = "thisisone.txt";
            ZipResult result = new ZipResult()
            {
                Entries = new[] { thisisoneTxt },
                ZipStream = new MemoryStream()
            };
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddress, emailAddress, subject, this.attachmentName);
            var body = mailService.MailMessage.Body;
            Assert.IsTrue(body.Contains(thisisoneTxt), "Message body does not contain the entry " + thisisoneTxt);
        }

        [Test]
        public void SendMail_MailMessageFileAttached()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = new MemoryStream()
            };
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddress, emailAddress, subject, this.attachmentName);
            var attachmentCollection = mailService.MailMessage.Attachments;
            Assert.AreEqual(1, attachmentCollection.Count);
        }

        [Test]
        public void SendMail_MailMessageCorrectFileAttached()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            var memoryStream = new MemoryStream();
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = memoryStream
            };
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddress, emailAddress, subject, this.attachmentName);
            var attachmentCollection = mailService.MailMessage.Attachments;
            Assert.AreSame(memoryStream, attachmentCollection.First().ContentStream);
        }

        [Test]
        public void SendMail_MailMessageCorrectAttachmentName()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            var memoryStream = new MemoryStream();
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = memoryStream
            };
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddress, emailAddress, subject, this.attachmentName);
            var attachmentCollection = mailService.MailMessage.Attachments;
            Assert.AreEqual(attachmentName, attachmentCollection.First().Name);
        }

        [Test]
        public void SendMail_MailMessageCorrectSubject()
        {
            MailServiceStub mailService = new MailServiceStub();
            Mailer mailer = new Mailer(mailService);
            var memoryStream = new MemoryStream();
            ZipResult result = new ZipResult()
            {
                Entries = new string[0],
                ZipStream = memoryStream
            };
            string subject = "this is the subject";
            mailer.SendZip(result, emailAddress, emailAddress, subject, this.attachmentName);
            var mailMessage = mailService.MailMessage;
            Assert.AreEqual(subject, mailMessage.Subject);
        }
    }
}