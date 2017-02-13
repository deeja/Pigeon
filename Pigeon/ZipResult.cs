namespace Pigeon
{
    using System;
    using System.IO;

    public class ZipResult : IDisposable
    {
        public Stream ZipStream { get; set; }

        public string[] Entries { get; set; }

        public void Dispose()
        {
            var fileStream = this.ZipStream;
            ((IDisposable)fileStream)?.Dispose();
        }
    }
}