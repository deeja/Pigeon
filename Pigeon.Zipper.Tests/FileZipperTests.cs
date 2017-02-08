using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pigeon.Zipper.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class FileZipperTests
    {

        [Test]
        public void ZipFiles_NoFiles_NoZip()
        {   
            FileZipper zipper = new FileZipper();
            ZipResult zipResult = zipper.ZipFiles(Enumerable.Empty<string>());
            Assert.IsNull(zipResult);
        }

        [Test]
        public void ZipFiles_OneFile_ZipResult()
        {   
            FileZipper zipper = new FileZipper();
            ZipResult zipResult = zipper.ZipFiles(new[] { "testfile.zip"});
            Assert.IsNotNull(zipResult);
        }
    }



}
