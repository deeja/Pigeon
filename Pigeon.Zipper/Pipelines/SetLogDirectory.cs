namespace Pigeon.Pipelines
{
    using Sitecore.Diagnostics;

    public class SetLogDirectory: PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args, "args != null");
            args.FileDirectory = Sitecore.Configuration.Settings.LogFolder;
        }
    }
}