namespace Pigeon.Zipper.Pipelines
{
    using Sitecore.Diagnostics;

    public class ZipFiles: PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            Assert.IsNotNull(args.FoundFiles,"args.FoundFiles != null");
            args.ZipResult = new FileZipper().ZipFiles(args.FoundFiles);
        }
    }
}