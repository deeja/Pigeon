namespace Pigeon.Zipper.Pipelines
{
    using Sitecore.Diagnostics;

    public class SetEmailAddress:PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            var pigeonEmailaddress = "Pigeon.EmailAddress";
            var emailAddress = Sitecore.Configuration.Settings.GetSetting(pigeonEmailaddress);
            Assert.IsNotNullOrEmpty(emailAddress,pigeonEmailaddress + " not set");
            args.EmailAddress = emailAddress;
        }
    }
}