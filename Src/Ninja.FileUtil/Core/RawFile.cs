namespace Ninja.FileUtil.Core
{
    public class RawFile
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string[] Lines { get; set; }
    }
}