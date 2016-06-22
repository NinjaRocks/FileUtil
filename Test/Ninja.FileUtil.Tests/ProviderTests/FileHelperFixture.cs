using System;
using System.IO;
using Ninja.FileUtil.Provider.Impl;
using NUnit.Framework;

namespace Ninja.FileUtil.Tests.ProviderTests
{
    [TestFixture]
    public class FileHelperFixture
    {
        [SetUp]
        public void Setup()
        {
            fileHelper = new FileHelper();
            filePath = Path.Combine(Environment.CurrentDirectory, "TestFile.txt");
            CreateFile(filePath);
        }

        private string filePath;
        private FileHelper fileHelper;

        public void CreateFile(string path)
        {
            using (var sr = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
                sr.Write("test one");
        }

        [Test]
        public void TestGetFilesForFileWhichDoesNotExistsShouldReturnEmptyFileCollection()
        {
            var lines = fileHelper.ReadToLines(filePath);
            Assert.That(lines.Length, Is.EqualTo(1));
        }
    }
}