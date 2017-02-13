namespace Pigeon
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    public class FileZipper
    {
        public ZipResult ZipFiles(IEnumerable<string> fileList)
        {
            if (!fileList.Any())
            {
                return null;
            }

            var stream = new MemoryStream();
            var zipFilesToStream = this.ZipFilesToStream(stream, fileList);
            return new ZipResult() { ZipStream = stream , Entries =  zipFilesToStream};
        }


        private string[] ZipFilesToStream(Stream stream, IEnumerable<string> fileNames)
        {
            List<string> entries = new List<string>();
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                foreach (var path in fileNames)
                {
                    var entryName = Path.GetFileName(path); // get filename
                    entries.Add(entryName);  // add to record of files that have been added 

                    ZipArchiveEntry archiveEntry = archive.CreateEntry(entryName, CompressionLevel.Optimal);

                    using (var entryStream = archiveEntry.Open())
                    {
                        using (FileStream fileStream = new FileStream(path, FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    }
                }
            }
            return entries.ToArray();
        }
    }
}
