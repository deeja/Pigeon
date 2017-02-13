namespace Pigeon.Pipelines
{
    using System.IO;

    using Sitecore.Diagnostics;

    public class FindLogs: PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args, "args != null");
            Assert.IsNotNullOrEmpty(args.FileDirectory, "args.FileDirectory != null");
            Assert.IsTrue(Directory.Exists(args.FileDirectory), "Folder does not exist: " + args.FileDirectory);
            FileFinder finder = new FileFinder(args.FileDirectory);
            args.FoundFiles = finder.FindLogFiles(args.StartDateTime, args.EndDateTime);
        }
    }
}