using System.Linq;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Parser;
using Ninja.FileUtil.Parser.Impl;
using Ninja.FileUtil.Provider;
using Ninja.FileUtil.Provider.Impl;

namespace Ninja.FileUtil
{
    public class Engine
    {
        private readonly IFileProvider provider;
        private readonly ILineParser lineParser;
        private readonly IParserSettings config;

        internal Engine(IFileProvider provider, ILineParser lineParser)
        {
            this.provider = provider;
            this.lineParser = lineParser;
        }

        public Engine(IParserSettings config, IFileProvider provider)
            : this(provider, new LineParser(config))
        {
            this.config = config;
        }

        public Engine(Settings settings)
            : this(settings.ParserSettings, new DefaulProvider(settings.ProviderSettings, new FileHelper()))
        {

        }

        /// <summary>
        /// Get all multi format lines from a text file parsed into header, data and footer 
        /// typed arrays respectively.
        /// Header line starts with H, data line starts with D and 
        /// footer line starts with F by defaults 
        /// Example File - 
        /// "H|22-10-2016|Employee Status"
        /// "D|John Walsh|456RT4|True"
        /// "D|Mark Walsh|456RT5|True"
        /// "F|2"
        /// </summary>
        /// <typeparam name="TH">Typed Header Line Class</typeparam>
        /// <typeparam name="TD">Typed Data Line Class</typeparam>
        /// <typeparam name="TF">Typed Footer Line Class</typeparam>
        /// <returns>
        /// Collection of Files each parsed with header, footer and data typed arrays
        /// </returns>
        public File<TH, TD, TF>[] GetFiles<TH, TD, TF>()
            where TH : FileLine, new()
            where TD : FileLine, new()
            where TF : FileLine, new()
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

                    Headers = lineParser.ParseWithLineType<TH>(file.Lines.Where(x => x.StartsWith(config.Header)).ToArray(), LineType.Header),
                    Footers = lineParser.ParseWithLineType<TF>(file.Lines.Where(x => x.StartsWith(config.Footer)).ToArray(), LineType.Footer),
                    Data = lineParser.ParseWithLineType<TD>(file.Lines.Where(x => x.StartsWith(config.Data)).ToArray(), LineType.Data)
                };

                return parsed;

            }).ToArray();
        }

        /// <summary>
        /// Get all single fixed format lines from a text file parsed into a strongly typed array
        /// Default delimiter is '|'
        /// Example File -
        /// "John Walsh|456RT4|True|Male"
        /// "Simone Walsh|456RT5|True|Female"
        /// </summary>
        /// <typeparam name="T">Typed Line Class</typeparam>
        /// <returns>
        /// Collection of Files each parsed with typed class arrays
        /// </returns>
        public File<T>[] GetFiles<T>() where T : FileLine, new()
        {
            var files = provider.GetFiles();
            return files.Select(file => new File<T>
            {
                FileMeta = new FileMeta
                {
                    FileName = file.FileName,
                    FilePath = file.FilePath,
                    FileSize = file.FileSize,
                    Lines = file.Lines,
                },

                Data = lineParser.ParseWithNoLineType<T>(file.Lines)
            }).ToArray();
        }
    }
}