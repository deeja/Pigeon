namespace Pigeon.Pipelines
{
    using Sitecore.Diagnostics;

    public class SetEmailAddresses:PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            var emailTo = Sitecore.Configuration.Settings.GetSetting(SettingKeys.EmailTo);
            var emailFrom = Sitecore.Configuration.Settings.GetSetting(SettingKeys.EmailFrom);
            Assert.IsNotNullOrEmpty(emailTo,emailTo + " not set");
            Assert.IsNotNullOrEmpty(emailFrom,emailFrom+ " not set");
            args.EmailTo = emailTo;
            args.EmailFrom = emailFrom;
        }
    }
}