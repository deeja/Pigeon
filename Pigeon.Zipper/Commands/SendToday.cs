namespace Pigeon.Zipper.Commands
{
    using System;

    using Pigeon.Zipper.Events;

    using Pipelines;

    using Sitecore.Pipelines;
    using Sitecore.Shell.Framework.Commands;

    public class SendToday: Command
    {
        public override void Execute(CommandContext context)
        {
            var start = DateTime.Today ;
            var end = DateTime.Today + TimeSpan.FromDays(1);
            EventRaiser.RaiseEvent(start, end);
        }
    }
}