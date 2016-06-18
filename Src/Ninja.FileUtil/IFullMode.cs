using Ninja.FileUtil.Parser;

namespace Ninja.FileUtil
{
    public interface IFullMode: IDelimiter
    {
        string Header { get; set; }
        string Footer { get; set; }
        string Data { get; set; }
    }
}