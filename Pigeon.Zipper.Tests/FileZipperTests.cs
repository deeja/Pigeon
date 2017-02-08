﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pigeon.Zipper.Tests
{
    using System.IO;

    using NUnit.Framework;

    using Sitecore.Zip;

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
            var readme = Path.Combine(GetTestLogDirectoryPath(), "readme.txt");
            ZipResult zipResult = zipper.ZipFiles(new[] { readme });
            Assert.IsNotNull(zipResult);
        }

        [Test]
        public void ZipFiles_OneFile_ZipResultContainsFile()
        {
            FileZipper zipper = new FileZipper();
            var readmeTxt = "readme.txt";
            var fullPath = Path.Combine(GetTestLogDirectoryPath(), readmeTxt);
            ZipResult zipResult = zipper.ZipFiles(new[] { fullPath });
            var entry = this.GetEntry(zipResult.ZipStream, readmeTxt);
            Assert.IsNotNull(entry);
        }

        [Test]
        public void ZipFiles_OneFile_ZipResultContainsFileWithCorrectContent()
        {
            FileZipper zipper = new FileZipper();
            var readmeTxt = "readme.txt";
            var fullPath = Path.Combine(GetTestLogDirectoryPath(), readmeTxt);
            ZipResult zipResult = zipper.ZipFiles(new[] { fullPath });
            var entry = this.GetEntry(zipResult.ZipStream, readmeTxt);
            StreamReader reader = new StreamReader(entry.GetStream());
            string text = reader.ReadToEnd();
            Assert.AreEqual("TEST_SUCCESS", text);
        }

        [Test]
        public void ZipFiles_OneFile_ZipResultContainsMultipleFiles()
        {
            var files = Directory.GetFiles(GetTestLogDirectoryPath(), "*.txt");
            Assert.Greater(files.Length, 5, "Missing Files for testing");

            FileZipper zipper = new FileZipper();
            using (ZipResult zipResult = zipper.ZipFiles(files))
            {
                var entries = this.GetEntries(zipResult.ZipStream);
                Assert.AreEqual(files.Length, entries.Count());
            }

            
        }

        private IEnumerable<ZipEntry> GetEntries(Stream zipStream)
        {
            ZipReader reader = new ZipReader(zipStream);
            return reader.Entries;
        }

        private ZipEntry GetEntry(Stream zipStream, string readme)
        {
            return GetEntries(zipStream).FirstOrDefault(entry => entry.Name == readme);
        }

        [Test]
        public void ZipFiles_TestLogs_Exists()
        {
            var testLogDir = GetTestLogDirectoryPath();
            Assert.True(Directory.Exists(testLogDir));
        }

        private static string GetTestLogDirectoryPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "TestLogs");
        }
    }



}