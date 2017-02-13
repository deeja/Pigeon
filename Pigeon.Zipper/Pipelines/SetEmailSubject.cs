namespace Pigeon.Pipelines
{
    using System;

    using Sitecore.Diagnostics;

    public class SetEmailSubject:PigeonPipelineProcessor
    {
        public override void Process(PigeonPipelineArgs args)
        {
            Assert.IsNotNull(args,"args != null");
            args.Subject = $"[Pigeon] {System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName()} {Environment.MachineName} - Date Range: {args.StartDateTime:G} -> {args.EndDateTime:G}";
        }
    }
}