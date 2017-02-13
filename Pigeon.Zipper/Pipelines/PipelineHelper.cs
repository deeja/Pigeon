namespace Pigeon.Pipelines
{
    using System;

    using Sitecore.Pipelines;

    public static class PipelineHelper
    {
        public const string PipelineName = "pigeon.Execute";

        public static void RunPipeline(DateTime start, DateTime end)
        {
            var pigeonPipelineArgs = new PigeonPipelineArgs()
                                         {
                                             StartDateTime = start,
                                             EndDateTime = end
                                         };

            CorePipeline.Run(PipelineName,pigeonPipelineArgs);
        }
    }
}