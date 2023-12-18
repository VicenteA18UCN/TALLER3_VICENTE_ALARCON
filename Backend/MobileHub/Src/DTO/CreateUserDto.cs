using System.ComponentModel.DataAnnotations;
using MobileHub.Src.DataAnnotations;

namespace MobileHub.Src.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) para crear un nuevo usuario.
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        /// Obtiene o establece el nombre completo del usuario.
        /// </summary>
        [Required(ErrorMessage = "The fullname is required")]
        [MaxLength(150, ErrorMessage = "The fullname must be less than 150 characters")]
        [MinLength(10, ErrorMessage = "The fullname must be at least 10 characters")]
        public string Fullname { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el RUT (Rol Único Tributario) del usuario.
        /// </summary>
        [Required(ErrorMessage = "The rut is required")]
        [Rut(ErrorMessage = "The rut is not valid")]
        public string Rut { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico del usuario.
        /// </summary>
        [Required(ErrorMessage = "The email is required")]
        [UCNEmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del usuario.
        /// </summary>
        [Required(ErrorMessage = "The birthday is required")]
        [BirthdateRange(ErrorMessage = "The birthday is not valid")]
        public int Birthday { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
