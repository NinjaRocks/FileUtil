using System.Linq;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Core;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using Ninja.FileUtil.Provider;

namespace Ninja.FileUtil
{
    public class Engine<T> where T: BaseFileLine, new()
    {
        private readonly IFileProvider provider;
        private readonly ILineParser<T> lineParser;

        public Engine(IFileProvider provider, ILineParser<T> lineParser)
        {
            this.provider = provider;
            this.lineParser = lineParser;
        }

        public Engine()
            : this(new DefaulProvider(new DefaultProviderSettings()), new LineParser<T>(new ParserSettings
            {
                Delimeter = '|',
                Data = "D",
                Header = "H",
                Footer = "F",
                IsPlain = false
            }))
        {
           
        }
        public File<T>[] GetFiles()
        {
            var files = provider.GetFiles();
            return files.Select(ParseFile).ToArray();
        }

        private File<T> ParseFile(RawFile file)
        {
            return new File<T>
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                Raw = file.Lines,
                Lines = lineParser.Parse(file.Lines)
            };
        }
    }
}
