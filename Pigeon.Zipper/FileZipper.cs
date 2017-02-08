using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pigeon.Zipper
{
    using System.IO;
    using System.IO.Compression;

    using Sitecore.Zip;

    public class FileZipper
    {
        public ZipResult ZipFiles(IEnumerable<string> fileList)
        {
            if (!fileList.Any())
            {
                return null;
            }

            var stream = new MemoryStream();
            this.ZipFilesToStream(stream, fileList);
            return new ZipResult() { ZipStream = stream };
        }


        private void ZipFilesToStream(Stream stream, IEnumerable<string> fileNames)
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                foreach (var name in fileNames)
                {
                    var entryName = Path.GetFileName(name);
                    ZipArchiveEntry archiveEntry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                    using (var entryStream = archiveEntry.Open())
                    {
                        using (FileStream fileStream = new FileStream(name, FileMode.Open))
                        {
                            fileStream.CopyTo(entryStream);
                        }
                        
                    }
                }
            }
        }
    }
}
