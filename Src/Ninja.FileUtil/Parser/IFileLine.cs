using System.Collections.Generic;

namespace Ninja.FileUtil.Parser
{
    public interface IFileLine
    {
        int Index { get;}
        LineType Type { get; }
        bool InError { get; }
        IList<string> Errors { get;}
    }
}