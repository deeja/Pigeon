namespace Pigeon.Zipper.Pipelines
{
    using Pigeon.Zipper.Adapters;

    using Sitecore.Diagnostics;

    public class EmailZip: PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            Assert.IsNotNullOrEmpty(args.EmailTo,"args.EmailTo != null");
            Assert.IsNotNullOrEmpty(args.AttachmentName,"args.AttachmentName != null");
            Assert.IsNotNullOrEmpty(args.Subject,"args.Subject != null");

            var mailer = new Mailer(new MailService());
            mailer.SendZip(args.ZipResult, args.EmailTo, args.EmailFrom, args.Subject, args.AttachmentName);
        }
    }
}