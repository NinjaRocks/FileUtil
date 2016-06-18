using System.Collections.Generic;

namespace Ninja.FileUtil.Parser
{
    public interface ILineParser 
    {
        T[] Parse<T>(IEnumerable<string> lines, LineType type) where T : IFileLine, new();
    }

}