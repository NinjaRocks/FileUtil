namespace Ninja.FileUtil.Parser
{
    internal interface ILineParser
    {
        T[] Parse<T>(string[] lines, LineType type) where T : IFileLine, new();
    }

}