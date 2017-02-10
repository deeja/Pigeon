namespace Pigeon.Zipper.Pipelines
{
    using System;

    using Sitecore.Diagnostics;
    using Sitecore.Web;

    public class SetEmailSubject:PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            args.Subject = $"[Pigeon] {System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName()} {Environment.MachineName} - Date Range: {args.StartDateTime:O} -> {args.EndDateTime:O}";
        }
    }
}