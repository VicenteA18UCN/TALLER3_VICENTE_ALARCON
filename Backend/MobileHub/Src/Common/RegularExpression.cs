using System.Text.RegularExpressions;

namespace MobileHub.Src.Common
{
    /// <summary>
    /// Expresión regular para validar dominios de correo electrónico de la UCN.
    /// </summary>
    public static partial class RegularExpressions
    {
        [GeneratedRegex("^(disc\\.ucn\\.cl|ce\\.ucn\\.cl|alumnos\\.ucn\\.cl|ucn\\.cl)$", RegexOptions.Compiled)] public static partial Regex UCNEmailDomainRegex();
    }

    /// <summary>
    /// Expresión regular para validar RUT (Rol Único Tributario) en Chile.
    /// </summary>
    public static partial class RegularExpressions
    {
        [GeneratedRegex("^([0-9]+-[0-9K])$", RegexOptions.Compiled)]
        public static partial Regex RutRegex();
    }
}