using System.Collections.Generic;
using Ninja.FileUtil.Parser;

namespace Ninja.FileUtil.Tests.ParserTests
{
    public class TestLine : IFileLine
    {
        public TestLine()
        {
            Errors = new List<string>();
        }

        [Column(0)]
        public string Name { get; set; }

        [Column(1)]
        public bool IsMember { get; set; }

        public int Index { get; set; }
        public LineType Type { get; set; }
        public IList<string> Errors { get; set; }
    }
}