using System.Linq;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using NUnit.Framework;
using ISimpleConfig = Ninja.FileUtil.Configuration.Simple.IConfiguration;
using IFullConfig = Ninja.FileUtil.Configuration.Full.IConfiguration;

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

            var prsed = parser.Parse<TestLine>(lines, LineType.Data);

            Assert.That(prsed.Length, Is.EqualTo(2));

            var first = prsed.First(x => x.Index == 0);
            Assert.That(first.Name, Is.EqualTo("Bob Marley"));
            Assert.That(first.IsMember, Is.EqualTo(true));
            Assert.That(first.Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(first.Errors);

            var second = prsed.First(x => x.Index == 1);
            Assert.That(second.Name, Is.EqualTo("John Walsh"));
            Assert.That(second.IsMember, Is.EqualTo(false));
            Assert.That(second.Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(second.Errors);
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

            var first = prsed.First(x => x.Index == 0);
            Assert.That(first.Name, Is.EqualTo("Bob Marley"));
            Assert.That(first.IsMember, Is.EqualTo(true));
            Assert.That(first.Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(first.Errors);

            var second = prsed.First(x => x.Index == 1);
            Assert.That(second.Name, Is.EqualTo("John Walsh"));
            Assert.That(second.IsMember, Is.EqualTo(false));
            Assert.That(second.Type, Is.EqualTo(LineType.Data));
            Assert.IsEmpty(second.Errors);
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

        [Test]
        public void TestParseForInvalidFileLineWithNoColumnAttributesShouldReturnError()
        {

            var result = parser.Parse<TestInvalidLine>(new[] { "edndx|medmd" }, LineType.Data);

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