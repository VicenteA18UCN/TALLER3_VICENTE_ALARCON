using System;
using System.ComponentModel.DataAnnotations;
using MobileHub.Src.Common;

namespace MobileHub.Src.DataAnnotations
{
    /// <summary>
    /// Atributo de validación personalizado para verificar si una dirección de correo electrónico
    /// cumple con el dominio específico de la Universidad Científica del Sur (UCN).
    /// </summary>
    public class UCNEmailAddressAttribute : ValidationAttribute
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCNEmailAddressAttribute"/>.
        /// </summary>
        public UCNEmailAddressAttribute()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCNEmailAddressAttribute"/> con un
        /// mensaje de error personalizado proporcionado mediante un delegado.
        /// </summary>
        /// <param name="errorMessageAccessor">Delegado para acceder al mensaje de error personalizado.</param>
        public UCNEmailAddressAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCNEmailAddressAttribute"/> con un
        /// mensaje de error personalizado.
        /// </summary>
        /// <param name="errorMessage">Mensaje de error personalizado.</param>
        public UCNEmailAddressAttribute(string errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// Determina si el valor de la dirección de correo electrónico cumple con el dominio específico
        /// de la Universidad Científica del Sur (UCN) y es una dirección de correo electrónico válida.
        /// </summary>
        /// <param name="value">Valor que se va a validar.</param>
        /// <returns>
        /// <c>true</c> si el valor es válido; de lo contrario, <c>false</c>.
        /// </returns>
        public override bool IsValid(object? value)
        {
            if (value is not string email) return false;

            var isValidEmail = new EmailAddressAttribute().IsValid(email);
            if (!isValidEmail) return false;

            try
            {
                var emailParts = email.Split('@')[1];
                return RegularExpressions.UCNEmailDomainRegex().IsMatch(emailParts);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
