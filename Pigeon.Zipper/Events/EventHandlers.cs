﻿namespace Pigeon.Zipper.Events
{
    using System;

    using Pigeon.Zipper.Pipelines;

    using Sitecore.Events;
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
            Event.RaiseEvent(EventNames.SendRemote, myEvent.Start, myEvent.End);
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
            SitecoreEventArgs sea = (SitecoreEventArgs)args;
            DateTime startDate = (DateTime)sea.Parameters[0];
            DateTime endDate = (DateTime)sea.Parameters[1];
            return new SendFilesEventRemote(startDate, endDate);
        }
    }
}