using System.Linq;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using Ninja.FileUtil.Provider;
using Ninja.FileUtil.Provider.Impl;

namespace Ninja.FileUtil
{
    public class Engine<T> where T: IFileLine, new()
    {
        private readonly IFileProvider provider;
        private readonly ILineParser lineParser;
        private readonly ISimpleMode config;
       
        internal Engine(IFileProvider provider, ILineParser lineParser)
        {
            this.provider = provider;
            this.lineParser = lineParser;
        }
        public Engine(ISimpleMode config, IFileProvider provider)
            : this(provider, new LineParser(config))
        {
            this.config = config;
        }
        public Engine(SimpleMode simpleModeConfig)
            : this(simpleModeConfig, new DefaulProvider(simpleModeConfig))
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
                FileMeta = new FileMeta
                {
                    FileName = file.FileName,
                    FilePath = file.FilePath,
                    FileSize = file.FileSize,
                    RawLines = file.Lines,
                },

                Data = lineParser.Parse<T>(file.Lines, LineType.Data)
            };
        }
    }
}
