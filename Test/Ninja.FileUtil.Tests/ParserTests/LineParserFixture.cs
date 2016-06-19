using Moq;

using Ninja.FileUtil.Parser;
using ISimpleConfig = Ninja.FileUtil.Configuration.Simple.IConfiguration;
using IFullConfig = Ninja.FileUtil.Configuration.Full.IConfiguration;
using Ninja.FileUtil.Parser.Impl;
using NUnit.Framework;

namespace Ninja.FileUtil.Tests.ParserTests
{
    [TestFixture]
    public class LineParserFixture
    {
        [SetUp]
        public void Setup()
        {
            parser = new LineParser(new TestSimpleConfig('|'));
        }
        
        private LineParser parser;

        [Test]
        public void TestParseForNullInputShouldReturnEmptyArray()
        {
            Assert.IsEmpty(parser.Parse<TestLine>(null, LineType.Data));
        }

        [Test]
        public void TestParseForValidSimpleInputShouldReturnCorrectlyParsedArray()
        {
            var lines = new[]
            {
                "Bob Marley|True",
                "John Walsh|False"
            };
            var prsed = parser.Parse<TestLine>(lines, LineType.Header);

            //Assert.That(prsed.Length, Is.EqualTo(1));
            Assert.That(prsed.Length, Is.EqualTo(2));

            Assert.That(prsed[0].Name, Is.EqualTo("Bob Marley"));
            Assert.That(prsed[0].IsMember, Is.EqualTo(true));
            Assert.That(prsed[0].Type, Is.EqualTo(LineType.Header));
            Assert.IsEmpty(prsed[0].Errors);

            Assert.That(prsed[1].Name, Is.EqualTo("John Walsh"));
            Assert.That(prsed[1].IsMember, Is.EqualTo(false));
            Assert.That(prsed[1].Type, Is.EqualTo(LineType.Header));
            Assert.IsEmpty(prsed[1].Errors);
        }

        [Test]
        public void TestParseForValidFullInputShouldReturnCorrectlyParsedArray()
        {
            parser = new LineParser(new TestFullConfig('|'));

            var lines = new[]
            {
                "D|Bob Marley|True",
                "D|John Walsh|False"
            };
            var prsed = parser.Parse<TestLine>(lines, LineType.Data);

            Assert.That(prsed.Length, Is.EqualTo(2));

            Assert.That(prsed[0].Name, Is.EqualTo("Bob Marley"));
            Assert.That(prsed[0].IsMember, Is.EqualTo(true));
            Assert.That(prsed[0].Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(prsed[0].Errors);

            Assert.That(prsed[1].Name, Is.EqualTo("John Walsh"));
            Assert.That(prsed[1].IsMember, Is.EqualTo(false));
            Assert.That(prsed[1].Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(prsed[1].Errors);
        }

        [TestCase("hbtrb", true)]
        [TestCase("hbtrb|ej ef|fer|", true)]
        [TestCase("H|hbtrb", false)]
        [TestCase("H|hbtrb|ej ef|fer|rc |", true)]
        public void TestParseForInvalidInputShouldReturnError(string line, bool isSimple)
        {
            if (!isSimple) parser = new LineParser(new TestFullConfig('|'));
            var result = parser.Parse<TestLine>(new []{line}, LineType.Data);

            Assert.IsNotEmpty(result[0].Errors);
        }
    }

    public class TestSimpleConfig : ISimpleConfig
    {
        public TestSimpleConfig(char delimeter)
        {
            Delimeter = delimeter;
        }

        public char Delimeter { get; set; }
    }

    public class TestFullConfig : IFullConfig
    {
        public TestFullConfig(char delimeter)
        {
            Delimeter = delimeter;
            Header = "H";
            Footer = "F";
            Data = "D";
        }

        public char Delimeter { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Data { get; set; }
    }
}