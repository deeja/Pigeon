namespace Pigeon.Commands
{
    using System;

    using Pigeon.Events;
    using Pigeon.Pipelines;

    using Sitecore.Shell.Framework.Commands;

    public class SendYesterday: Command
    {
        public override void Execute(CommandContext context)
        {
            var start = DateTime.Today - TimeSpan.FromDays(1);
            var end = DateTime.Today;
            PipelineHelper.RunPipeline(start, end); // run the pipeline
            EventRaiser.RaiseEvent(start, end);
        }
    }
}