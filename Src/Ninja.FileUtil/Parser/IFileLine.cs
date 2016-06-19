using System.Collections.Generic;

namespace Ninja.FileUtil.Parser
{
    public interface IFileLine
    {
        int Index { get; set; }
        LineType Type { get; set; }
        
        IList<string> Errors { get; set; }
    }
}