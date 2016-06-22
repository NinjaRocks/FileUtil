using System.Linq;
using Ninja.FileUtil.Configuration.Full;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using Ninja.FileUtil.Provider;
using Ninja.FileUtil.Provider.Impl;

namespace Ninja.FileUtil
{
    public class Engine<TH, TD, TF>
        where TH : IFileLine, new()
        where TD : IFileLine, new()
        where TF : IFileLine, new()
    {
        private readonly IFileProvider provider;
        private readonly ILineParser lineParser;
        private readonly IConfiguration config;

        internal Engine(IFileProvider provider, ILineParser lineParser)
        {
            this.provider = provider;
            this.lineParser = lineParser;
        }

        public Engine(IConfiguration config, IFileProvider provider)
            : this(provider, new LineParser(config))
        {
            this.config = config;
        }

        public Engine(Settings settings)
            : this(settings.ParserSettings, new DefaulProvider(settings.ProviderSettings, new FileHelper()))
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
                        Lines = file.Lines,
                    },

                    Headers = lineParser.Parse<TH>(file.Lines.Where(x => x.StartsWith(config.Header)).ToArray(), LineType.Header),
                    Footers = lineParser.Parse<TF>(file.Lines.Where(x => x.StartsWith(config.Footer)).ToArray(), LineType.Footer),
                    Data = lineParser.Parse<TD>(file.Lines.Where(x => x.StartsWith(config.Data)).ToArray(), LineType.Data)
                };

                return parsed;

            }).ToArray();
        }
    }
}
