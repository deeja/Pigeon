namespace Pigeon.Zipper.Pipelines
{
    using Sitecore.Pipelines;

    public abstract class PigeonPipelineProcessor
    {
        public abstract void Process(PipelineArgs args);
    }
}