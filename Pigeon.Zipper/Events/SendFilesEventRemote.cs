namespace Pigeon.Events
{
    using System;

    [Serializable]
    public class SendFilesEventRemote
    {
        public SendFilesEventRemote(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }

        public SendFilesEventRemote() { }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}