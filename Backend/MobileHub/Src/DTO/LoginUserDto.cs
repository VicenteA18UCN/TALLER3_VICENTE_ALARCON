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
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;


        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; } = string.Empty;
    }
}