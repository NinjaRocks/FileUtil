namespace Ninja.FileUtil.Example.Impl
{
    public static class Extensions
    {
        public static string GetValueOrDefault(this string input, string value)
        {
            return string.IsNullOrWhiteSpace(input) ? value : input;
        }
    }
}