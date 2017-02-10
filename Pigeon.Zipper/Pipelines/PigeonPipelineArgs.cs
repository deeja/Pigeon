namespace Pigeon.Zipper.Pipelines
{
    using System;

    using Sitecore.Pipelines;

    public class PigeonPipelineArgs: PipelineArgs
    {
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string[] FoundFiles { get; set; }

        public string FileDirectory { get; set; }

        public ZipResult ZipResult { get; set; }

        public string EmailAddress { get; set; }

        public string AttachmentName { get; set; }
    }
}