namespace Pigeon.Zipper
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization.Configuration;

    using Sitecore.Diagnostics;

    public class FileFinder
    {
        private readonly string logDirectory;

        /// <summary>
        /// First group is the date, second is the time
        /// </summary>
        static readonly Regex DateRegex = new Regex(@"\.(2[01][123][0-9][0-1][0-9][0-3][0-9])\.([0-2][0-9][0-5][0-9][0-5][0-9]){0,1}");

        public FileFinder(string logDirectory)
        {
            this.logDirectory = logDirectory;
        }

        public string[] FindLogFiles(DateTime start, DateTime end)
        {
            if (end < start)
            {
                throw new ArgumentException("Start date should be before end date", nameof(start));
            }

            var files = Directory.GetFiles(this.logDirectory);
            return files.Where(this.HasDate)
                .Select(s => new { file = s, date = this.GetDate(s) })
                .Where(arg => arg.date >= start)
                .Where(arg => arg.date < end)
                .Select(arg => arg.file).ToArray();
        }

        private bool HasDate(string fileName)
        {
            return DateRegex.IsMatch(fileName);
        }

        private DateTime GetDate(string filename)
        {
            var match = DateRegex.Match(filename);
            var dateSection = match.Groups[1].Captures[0].Value;
            if (this.HasTime(match))
            {
                var timeSection = match.Groups[2].Captures[0].Value;
                return DateTime.ParseExact(dateSection + timeSection, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            }

            return DateTime.ParseExact(dateSection, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        private bool HasTime(Match match)
        {
            return match.Groups[2].Captures.Count == 1;
        }
    }
}