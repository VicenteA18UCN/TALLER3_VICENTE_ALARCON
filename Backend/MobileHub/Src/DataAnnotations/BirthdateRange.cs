using System;
using System.ComponentModel.DataAnnotations;

namespace MobileHub.Src.DataAnnotations
{
    /// <summary>
    /// Atributo de validación personalizado para verificar si la fecha de nacimiento está en un rango válido.
    /// </summary>
    public class BirthdateRange : ValidationAttribute
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BirthdateRange"/>.
        /// </summary>
        public BirthdateRange()
        {
            ErrorMessage = "The age birthday is not valid";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BirthdateRange"/> con un
        /// mensaje de error personalizado proporcionado mediante un delegado.
        /// </summary>
        /// <param name="errorMessageAccessor">Delegado para acceder al mensaje de error personalizado.</param>
        public BirthdateRange(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BirthdateRange"/> con un
        /// mensaje de error personalizado.
        /// </summary>
        /// <param name="errorMessage">Mensaje de error personalizado.</param>
        public BirthdateRange(string errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// Determina si el valor de la fecha de nacimiento cumple con el rango válido.
        /// </summary>
        /// <param name="value">Valor que se va a validar.</param>
        /// <returns>
        /// <c>true</c> si el valor es válido; de lo contrario, <c>false</c>.
        /// </returns>
        public override bool IsValid(object? value)
        {
            var birthday = (int?)value ?? 0;
            if (birthday < 1900 || birthday > DateTime.Now.Year) return false;
            return true;
        }
    }
}
