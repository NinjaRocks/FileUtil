namespace Ninja.FileUtil.Configuration.Full
{
    public interface IConfiguration: IDelimiter
    {
        string Header { get; set; }
        string Footer { get; set; }
        string Data { get; set; }
    }
}