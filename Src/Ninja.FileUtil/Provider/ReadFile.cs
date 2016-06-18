using Ninja.FileUtil.Parser;

namespace Ninja.FileUtil.Provider
{
    public class ReadFile
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string[] Lines { get; set; }
    }
}