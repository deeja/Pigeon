namespace Pigeon.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class FileFinderTests
    {
        private readonly string path = Path.Combine(Directory.GetCurrentDirectory(), "TestLogs");

        [Test]
        public void FindLogFiles_NoFilesForDateRangeInPast()
        {
            FileFinder fileFinder = new FileFinder(this.path);
            DateTime start = new DateTime(1990, 11, 10, 9, 8, 7);
            DateTime end = new DateTime(1990, 12, 10, 9, 8, 7);
            var files = fileFinder.FindLogFiles(start, end);
            Assert.IsEmpty(files, "Should be no files");
        }

        [Test]
        public void FindLogFiles_NoFilesForDateRangeInFuture()
        {
            FileFinder fileFinder = new FileFinder(this.path);
            DateTime start = new DateTime(3000, 11, 10, 9, 8, 7);
            DateTime end = new DateTime(3001, 12, 10, 9, 8, 7);
            var files = fileFinder.FindLogFiles(start, end);
            Assert.IsEmpty(files, "Should be no files");
        }

        [Test]
        public void FindLogFiles_AllTestLogs()
        {
            FileFinder fileFinder = new FileFinder(this.path);
            DateTime end = new DateTime(2018, 11, 10, 9, 8, 7);
            DateTime start = new DateTime(2016, 12, 10, 9, 8, 7);
            var files = fileFinder.FindLogFiles(start, end);
            Assert.AreEqual(10, files.Length);
        }

        [Test]
        public void FindLogFiles_SpecificDate_ReturnsLogs()
        {
            FileFinder fileFinder = new FileFinder(this.path);
            DateTime start = new DateTime(2017, 2, 2);
            DateTime end = new DateTime(2017, 2, 2, 23, 59, 59);
            var files = fileFinder.FindLogFiles(start, end);
            Assert.AreEqual(8, files.Length);
        }

        [Test]
        public void FindLogFiles_SpecificDateAndTime_Return()
        {
            FileFinder fileFinder = new FileFinder(this.path);
            DateTime start = new DateTime(2017, 2, 2, 12, 1, 1);
            DateTime end = new DateTime(2017, 2, 2, 13, 1, 1);
            var files = fileFinder.FindLogFiles(start, end);
            Assert.AreEqual(4, files.Length);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void FindLogFiles_StartDateAfterEndDate_ThrowException()
        {
            FileFinder fileFinder = new FileFinder(this.path);
            DateTime end = new DateTime(2016, 12, 10, 9, 8, 7);
            DateTime start = new DateTime(2018, 11, 10, 9, 8, 7);
            var files = fileFinder.FindLogFiles(start, end);
        }

    }
}