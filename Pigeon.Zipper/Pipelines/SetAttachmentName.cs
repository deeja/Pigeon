namespace Pigeon.Pipelines
{
    using Sitecore.Diagnostics;

    public class SetAttachmentName:PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args, "args != null");
            var pigeonAttachmentname = "Pigeon.AttachmentName";
            var setting = Sitecore.Configuration.Settings.GetSetting(pigeonAttachmentname);
            Assert.IsNotNullOrEmpty(setting, pigeonAttachmentname + " has not been set. ");
            args.AttachmentName = setting;
        }
    }
}