using System.Collections.Generic;

namespace Ninja.FileUtil
{
    internal interface IFileLine
    {
        int Index { get; set; }
        LineType Type { get; set; }
        IList<string> Errors { get; set; }
    }
}