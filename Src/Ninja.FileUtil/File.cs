using Ninja.FileUtil.Parser;

namespace Ninja.FileUtil
{
    public class File<T> where T: IFileLine
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string[] Raw { get; set; }
        public T[] Lines { get; set; }
    }
}