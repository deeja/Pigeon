namespace Pigeon.Tasks
{
    using Pigeon.Commands;
    using Pigeon.Events;

    using Sitecore.Tasks;
    using Sitecore.Data.Items;
    using Sitecore.Shell.Framework.Commands;

    public class SendLogs
    {
        public void SendYesterdays(Item[] items, CommandItem command, ScheduleItem schedule)
        {
            new SendYesterday().Execute(CommandContext.Empty);
        }
    }
}