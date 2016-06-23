namespace Ninja.FileUtil.Tests.Engine
{
    public class FooterLine : FileLine
    {
        [Column(0)]
        public int TotalRecords { get; set; }
    }
}