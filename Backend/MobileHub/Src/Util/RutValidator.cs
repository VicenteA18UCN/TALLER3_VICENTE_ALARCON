using System.Text.RegularExpressions;
using MobileHub.Src.Common;

namespace MobileHub.Src.Util
{
    /// <summary>
    /// Clase que proporciona métodos para validar y verificar RUT (Rol Único Tributario) chileno.
    /// </summary>
    public class RutValidator
    {
        /// <summary>
        /// Método para validar un valor como un RUT.
        /// </summary>
        /// <param name="value">Valor a validar como RUT.</param>
        /// <returns>
        /// Devuelve true si el valor es un RUT válido; de lo contrario, false.
        /// </returns>
        public static bool IsValid(object? value)
        {
            var rut = value?.ToString() ?? string.Empty;
            if (rut.Length < 10 || rut.Length > 12) return false;
            return CheckRut(rut);
        }

        /// <summary>
        /// Método para verificar la validez de un RUT chileno.
        /// </summary>
        /// <param name="rut">RUT a verificar.</param>
        /// <returns>
        /// Devuelve true si el RUT es válido; de lo contrario, false.
        /// </returns>
        public static bool CheckRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            if (!RegularExpressions.RutRegex().IsMatch(rut))
                return false;
            string dv = rut.Substring(rut.Length - 1, 1);
            char[] dash = { '-' };
            string[] splittedRut = rut.Split(dash);
            if (dv != CalculateDigit(int.Parse(splittedRut[0])))
                return false;
            return true;
        }

        /// <summary>
        /// Método para calcular el dígito verificador de un número de RUT.
        /// </summary>
        /// <param name="rut">Número de RUT sin dígito verificador.</param>
        /// <returns>
        /// Devuelve el dígito verificador calculado.
        /// </returns>
        public static string CalculateDigit(int rut)
        {
            int sum = 0;
            int multiplier = 1;
            while (rut != 0)
            {
                multiplier++;
                if (multiplier == 8)
                    multiplier = 2;
                sum += rut % 10 * multiplier;
                rut /= 10;
            }
            sum = 11 - (sum % 11);

            return sum switch
            {
                11 => "0",
                10 => "K",
                _ => sum.ToString(),
            };
        }
    }
}
