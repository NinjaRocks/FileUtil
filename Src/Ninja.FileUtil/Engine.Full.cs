using System.Linq;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using Ninja.FileUtil.Provider;
using Ninja.FileUtil.Provider.Impl;

namespace Ninja.FileUtil
{
    public class Engine<TH, TD, TF> where TH : IFileLine, new()
                                    where TD : IFileLine, new()
                                    where TF : IFileLine, new()
    {
        private readonly IFileProvider provider;
        private readonly ILineParser lineParser;
        private readonly IFullMode config;

        internal Engine(IFileProvider provider, ILineParser lineParser)
        {
            this.provider = provider;
            this.lineParser = lineParser;
        }
        public Engine(IFullMode config, IFileProvider provider)
            : this(provider, new LineParser(config))
        {
            this.config  = config;
        }
        public Engine(FullMode fullModeConfig)
            : this(fullModeConfig, new DefaulProvider(fullModeConfig))
        {

        }

        public File<TH, TD, TF>[] GetFiles()
        {
            var files = provider.GetFiles();

            return files.Select(file =>
            {
                var parsed = new File<TH, TD, TF>
                {
                    FileMeta = new FileMeta
                    {
                        FileName = file.FileName,
                        FilePath = file.FilePath,
                        FileSize = file.FileSize,
                        RawLines = file.Lines,
                    },

                    Headers = lineParser.Parse<TH>(file.Lines.Where(x => x.StartsWith(config.Header)), LineType.Header),
                    Footers = lineParser.Parse<TF>(file.Lines.Where(x => x.StartsWith(config.Footer)), LineType.Footer),
                    Data = lineParser.Parse<TD>(file.Lines.Where(x => x.StartsWith(config.Data)), LineType.Data)
                };

                return parsed;

            }).ToArray();
        }
    }
}
