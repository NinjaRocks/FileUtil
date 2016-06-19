

using System.Linq;
using Ninja.FileUtil.Configuration.Simple;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using Ninja.FileUtil.Provider;
using Ninja.FileUtil.Provider.Impl;

namespace Ninja.FileUtil
{
    public class Engine<T> where T : IFileLine, new()
    {
        private readonly IFileProvider provider;
        private readonly ILineParser lineParser;

        internal Engine(IFileProvider provider, ILineParser lineParser)
        {
            this.provider = provider;
            this.lineParser = lineParser;
        }

        public Engine(IConfiguration config, IFileProvider provider)
            : this(provider, new LineParser(config))
        {

        }

        public Engine(Settings settings)
            : this(settings.ParserSettings, new DefaulProvider(settings.ProviderSettings, new FileHelper()))
        {

        }

        public File<T>[] GetFiles()
        {
            var files = provider.GetFiles();
            return files.Select(ParseFile).ToArray();
        }

        private File<T> ParseFile(FileMeta file)
        {
            return new File<T>
            {
                FileMeta = new FileMeta
                {
                    FileName = file.FileName,
                    FilePath = file.FilePath,
                    FileSize = file.FileSize,
                    Lines = file.Lines,
                },

                Data = lineParser.Parse<T>(file.Lines, LineType.Data)
            };
        }
    }
}
