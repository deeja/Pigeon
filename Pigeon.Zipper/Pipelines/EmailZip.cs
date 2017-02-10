namespace Pigeon.Zipper.Pipelines
{
    using Pigeon.Zipper.Adapters;

    using Sitecore.Diagnostics;

    public class EmailZip: PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            Assert.IsNotNull(args.ZipResult,"args.ZipResult != null");
            Assert.IsNotNullOrEmpty(args.EmailAddress,"args.EmailAddress != null");
            Assert.IsNotNullOrEmpty(args.AttachmentName,"args.AttachmentName != null");

            new Mailer(new MailService()).SendZip(args.ZipResult, args.EmailAddress, args.AttachmentName);
        }
    }
}