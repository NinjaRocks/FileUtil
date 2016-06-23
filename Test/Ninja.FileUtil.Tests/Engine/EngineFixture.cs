using System;
using Moq;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Provider;
using NUnit.Framework;

namespace Ninja.FileUtil.Tests.Engine
{
    [TestFixture]
    public class EngineFixture
    {
        private Mock<IFileProvider> provider;
        private Mock<IParserSettings> configuration;
        private FileUtil.Engine engine;

        [SetUp]
        public void Setup()
        {
            provider = new Mock<IFileProvider>();
            configuration = new Mock<IParserSettings>();

            configuration.Setup(x => x.Delimiter).Returns('|');
            configuration.Setup(x => x.Header).Returns("H");
            configuration.Setup(x => x.Data).Returns("D");
            configuration.Setup(x => x.Footer).Returns("F");

            engine = new FileUtil.Engine(configuration.Object, provider.Object);
        }

        [Test]
        public void TestGetFilesMultiFormatForNoFileFromProviderShouldReturnEmptyCollection()
        {
            Assert.IsEmpty(engine.GetFiles<HeaderLine, DataLine, FooterLine>());
        }

        [Test]
        public void TestGetFilesMultiFormatForFileReceivedFromProviderShouldReturnParsedCollection()
        {
            var date = new DateTime(2016, 10, 22);
            var fileMeta = new FileMeta
            {
                FileName = "name",
                FilePath = "path",
                FileSize = 1234,
                Lines = new[] { string.Format("H|{0}|Employee Status",date.ToShortDateString()), "D|John Walsh|456RT4|True", "F|1" }
            };

            provider.Setup(x => x.GetFiles()).Returns(new[] { fileMeta });

            var parsedfiles = engine.GetFiles<HeaderLine, DataLine, FooterLine>();

            Assert.IsNotEmpty(parsedfiles);
            Assert.That(parsedfiles[0].FileMeta.FileName, Is.EqualTo(fileMeta.FileName));
            Assert.That(parsedfiles[0].FileMeta.FilePath, Is.EqualTo(fileMeta.FilePath));
            Assert.That(parsedfiles[0].FileMeta.FileSize, Is.EqualTo(fileMeta.FileSize));
            Assert.That(parsedfiles[0].FileMeta.Lines, Is.EqualTo(fileMeta.Lines));

            Assert.IsAssignableFrom<HeaderLine>(parsedfiles[0].Headers[0]);

            Assert.That(parsedfiles[0].Headers[0].Index, Is.EqualTo(0));
            Assert.That(parsedfiles[0].Headers[0].Type, Is.EqualTo(LineType.Header));
            Assert.IsEmpty(parsedfiles[0].Headers[0].Errors);
            Assert.That(parsedfiles[0].Headers[0].Date, Is.EqualTo(date));
            Assert.That(parsedfiles[0].Headers[0].Name, Is.EqualTo("Employee Status"));


            Assert.IsAssignableFrom<DataLine>(parsedfiles[0].Data[0]);

            Assert.That(parsedfiles[0].Data[0].Index, Is.EqualTo(0));
            Assert.That(parsedfiles[0].Data[0].Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(parsedfiles[0].Data[0].Errors);

            Assert.That(parsedfiles[0].Data[0].Employee, Is.EqualTo("John Walsh"));
            Assert.That(parsedfiles[0].Data[0].Reference, Is.EqualTo("456RT4"));
            Assert.That(parsedfiles[0].Data[0].InService, Is.EqualTo(true));

            Assert.IsAssignableFrom<FooterLine>(parsedfiles[0].Footers[0]);

            Assert.That(parsedfiles[0].Footers[0].Index, Is.EqualTo(0));
            Assert.That(parsedfiles[0].Footers[0].Type, Is.EqualTo(LineType.Footer));
            Assert.IsEmpty(parsedfiles[0].Footers[0].Errors);

            Assert.That(parsedfiles[0].Footers[0].TotalRecords, Is.EqualTo(1));
        }

        [Test]
        public void TestGetFilesSingleFormatForNoFileFromProviderShouldReturnEmptyCollection()
        {
            Assert.IsEmpty(engine.GetFiles<SingleLine>());
        }

        [Test]
        public void TestGetFilesSungleFormatForFileReceivedFromProviderShouldReturnParsedCollection()
        {
            var fileMeta = new FileMeta
            {
                FileName = "name",
                FilePath = "path",
                FileSize = 1234,
                Lines = new[] { 
                    "Jack Marias|false"
         //           , "Samuel Dias|true" 
                }
            };

            provider.Setup(x => x.GetFiles()).Returns(new[] { fileMeta });

            var parsedfiles = engine.GetFiles<SingleLine>();

            Assert.IsNotEmpty(parsedfiles);
            Assert.That(parsedfiles[0].FileMeta.FileName, Is.EqualTo(fileMeta.FileName));
            Assert.That(parsedfiles[0].FileMeta.FilePath, Is.EqualTo(fileMeta.FilePath));
            Assert.That(parsedfiles[0].FileMeta.FileSize, Is.EqualTo(fileMeta.FileSize));
            Assert.That(parsedfiles[0].FileMeta.Lines, Is.EqualTo(fileMeta.Lines));


            Assert.IsAssignableFrom<SingleLine>(parsedfiles[0].Data[0]);
            //Assert.IsAssignableFrom<SingleLine>(parsedfiles[0].Data[1]);

            Assert.That(parsedfiles[0].Data[0].Index, Is.EqualTo(0));
            Assert.That(parsedfiles[0].Data[0].Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(parsedfiles[0].Data[0].Errors);

            Assert.That(parsedfiles[0].Data[0].Name, Is.EqualTo("Jack Marias"));
            Assert.That(parsedfiles[0].Data[0].IsMember, Is.EqualTo(false));

            /*
            Assert.That(parsedfiles[0].Data[1].Index, Is.EqualTo(1));
            Assert.That(parsedfiles[0].Data[1].Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(parsedfiles[0].Data[0].Errors);

            Assert.That(parsedfiles[0].Data[1].Name, Is.EqualTo("Samuel Dias"));
            Assert.That(parsedfiles[0].Data[1].IsMember, Is.EqualTo(true));
            */
        }
    }
}
