namespace Pigeon.Zipper.Events
{
    using System;

    using Pigeon.Zipper.Pipelines;

    public static class EventRaiser
    {
        public static void RaiseEvent(DateTime start, DateTime end)
        {
            var parameters = new object[] { start, end};
            Sitecore.Events.Event.RaiseEvent(EventNames.Send, parameters);
        }
    }
}