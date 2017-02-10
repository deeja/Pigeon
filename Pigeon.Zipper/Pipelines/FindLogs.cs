namespace Pigeon.Zipper.Pipelines
{
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines;

    public class FindLogs: PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args, "args != null");
            Assert.IsNotNull(args.FileDirectory, "args.FileDirectory != null");
            FileFinder finder = new FileFinder(args.FileDirectory);
            args.FoundFiles = finder.FindLogFiles(args.StartDateTime, args.EndDateTime);
        }
    }
}