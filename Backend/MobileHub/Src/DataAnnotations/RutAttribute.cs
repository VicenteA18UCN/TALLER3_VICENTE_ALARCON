using System;
using System.ComponentModel.DataAnnotations;
using MobileHub.Src.Util;

namespace MobileHub.Src.DataAnnotations
{
    /// <summary>
    /// Atributo de validación personalizado para verificar si un RUT (Rol Único Tributario) es válido.
    /// </summary>
    public class RutAttribute : ValidationAttribute
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RutAttribute"/>.
        /// </summary>
        public RutAttribute()
        {
            ErrorMessage = "The RUT is not valid";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RutAttribute"/> con un
        /// mensaje de error personalizado proporcionado mediante un delegado.
        /// </summary>
        /// <param name="errorMessageAccessor">Delegado para acceder al mensaje de error personalizado.</param>
        public RutAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RutAttribute"/> con un
        /// mensaje de error personalizado.
        /// </summary>
        /// <param name="errorMessage">Mensaje de error personalizado.</param>
        public RutAttribute(string errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// Determina si el valor del RUT cumple con el formato y la validación del RUT chileno.
        /// </summary>
        /// <param name="value">Valor que se va a validar.</param>
        /// <returns>
        /// <c>true</c> si el valor es válido; de lo contrario, <c>false</c>.
        /// </returns>
        public override bool IsValid(object? value)
        {
            var rut = value?.ToString() ?? string.Empty;
            if (rut.Length < 10 || rut.Length > 12) return false;
            return RutValidator.CheckRut(rut);
        }
    }
}
