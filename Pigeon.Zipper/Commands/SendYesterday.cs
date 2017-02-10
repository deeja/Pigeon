namespace Pigeon.Zipper.Commands
{
    using System;

    using Pipelines;

    using Sitecore.Pipelines;
    using Sitecore.Shell.Framework.Commands;

    public class SendYesterday: Command
    {
        public override void Execute(CommandContext context)
        {
            var pipelineArgs = new PigeonPipelineArgs()
                                   {
                                       StartDateTime = DateTime.Today - TimeSpan.FromDays(1),
                                       EndDateTime = DateTime.Today
                                   };
            CorePipeline.Run("pigeon.Execute", pipelineArgs);
        }
    }
}