namespace Ninja.FileUtil.Parser
{

    public class ErrorMessage
    {
        public const string InvalidLineFormat = "Invalid line format - is not delimeter separated";
        public const string LineExceptionFormat = "{0} failed to parse with error - {1}";
        public const string NoColumnAttributesFoundFormat = "No column attributes found on Line  - {0}";
        public const string InvalidLengthErrorFormat = "Invalid line format - number of column values do not match";
        public const string InvalidEnumValueErrorFormat = "{0} failed to parse - Invalid enum value";
        public const string InvalidTypeValueError = "Invalid line format -  Invalid line type value";
    }

}