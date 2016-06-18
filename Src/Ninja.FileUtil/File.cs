using Ninja.FileUtil.Parser;

namespace Ninja.FileUtil
{
    public class File<T> where T: IFileLine
    {
        public FileMeta FileMeta { get; set; }
        public T[] Data { get; set; }
       
    }

    public class File<TH, TD, TF> where TH : IFileLine, new()
                                  where TD : IFileLine, new()
                                  where TF : IFileLine, new()
    {
        public FileMeta FileMeta { get; set; }
        public TH[] Headers { get; set; }
        public TD[] Data { get; set; }
        public TF[] Footers { get; set; }

    }
    public class FileMeta
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string[] RawLines { get; set; }
    }
}