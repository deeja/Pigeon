namespace Pigeon.Zipper.Commands
{
    using System;

    using Pigeon.Zipper.Events;

    using Pipelines;

    using Sitecore.Pipelines;
    using Sitecore.Shell.Framework.Commands;

    public class SendYesterday: Command
    {
        public override void Execute(CommandContext context)
        {
            var start = DateTime.Today - TimeSpan.FromDays(1);
            var end = DateTime.Today;
            EventRaiser.RaiseEvent(start, end);
        }
    }
}