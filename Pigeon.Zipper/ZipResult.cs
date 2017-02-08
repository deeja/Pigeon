namespace Pigeon.Zipper
{
    using System;
    using System.IO;

    public class ZipResult : IDisposable
    {
        public Stream ZipStream { get; set; }

        public void Dispose()
        {
            var fileStream = this.ZipStream;
            ((IDisposable)fileStream)?.Dispose();
        }
    }
}