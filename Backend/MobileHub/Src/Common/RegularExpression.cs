using System.Text.RegularExpressions;

namespace MobileHub.Src.Common
{
    public static partial class RegularExpressions
    {
        [GeneratedRegex("^([a-zA-Z]+\\.)*ucn\\.cl$", RegexOptions.Compiled)]
        public static partial Regex UCNEmailDomainRegex();
    }

        public static partial class RegularExpressions
    {
        [GeneratedRegex("^([0-9]+-[0-9K])$", RegexOptions.Compiled)]
        public static partial Regex RutRegex();
    }
}