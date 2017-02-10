namespace Pigeon.Zipper.Events
{
    using System;

    using Pigeon.Zipper.Pipelines;

    using Sitecore.Pipelines;

    public class EventHandlers
    {
        public virtual void InitializeFromPipeline(PipelineArgs args)
        {
            var action = new Action<SendFilesEventRemote>(this.RaiseRemoteEvent);
            Sitecore.Eventing.EventManager.Subscribe(action);
        }

        private void RaiseRemoteEvent(SendFilesEventRemote myEvent)
        {
            Sitecore.Events.Event.RaiseEvent(EventNames.SendRemote, myEvent.Start, myEvent.End);
        }

        protected virtual void SendEventRemote(object sender, EventArgs args)
        {
            var sendFilesEventRemote = CreateSendFilesEventRemote(args);
            PipelineHelper.RunPipeline(sendFilesEventRemote.Start, sendFilesEventRemote.End);
        }

        protected virtual void SendEvent(object sender, EventArgs args)
        {
            var e = CreateSendFilesEventRemote(args);
            Sitecore.Eventing.EventManager.QueueEvent(e);
        }

        private static SendFilesEventRemote CreateSendFilesEventRemote(EventArgs args)
        {
            var startDate = Sitecore.Events.Event.ExtractParameter<string>(args, 0);
            var endDate = Sitecore.Events.Event.ExtractParameter<string>(args, 1);
            var e = new SendFilesEventRemote(
                EventDateHelper.DeserialiseDate(startDate),
                EventDateHelper.DeserialiseDate(endDate));
            return e;
        }
    }
}