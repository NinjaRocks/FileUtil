namespace Ninja.FileUtil.Parser
{

    public interface ILineParser<out T> where T : IFileLine, new()
    {
        T[] Parse( string[] lines);
    }

}