﻿namespace Pigeon.Pipelines
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

        public string EmailTo { get; set; }

        public string AttachmentName { get; set; }

        public string EmailFrom { get; set; }

        public string Subject { get; set; }

        protected override void Dispose()
        {
            var zipResult = this.ZipResult;
            zipResult?.Dispose();
            base.Dispose();
        }
    }
}