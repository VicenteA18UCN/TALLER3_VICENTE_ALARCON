using System.ComponentModel.DataAnnotations;

namespace MobileHub.Src.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) para autenticar un usuario.
    /// </summary>
    public class LoginUserDto
    {
        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico del usuario.
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }
}