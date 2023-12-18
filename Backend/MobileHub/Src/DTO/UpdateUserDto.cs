using System.ComponentModel.DataAnnotations;
using MobileHub.Src.DataAnnotations;

namespace MobileHub.Src.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) para actualizar la información de un usuario.
    /// </summary>
    public class UpdateUserDto
    {
        /// <summary>
        /// Obtiene o establece el nombre completo del usuario.
        /// </summary>
        [MaxLength(150, ErrorMessage = "The fullname must be less than 150 characters")]
        [MinLength(10, ErrorMessage = "The fullname must be at least 10 characters")]
        public string Fullname { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        [UCNEmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del usuario.
        /// </summary>
        [BirthdateRange(ErrorMessage = "The age birthday is not valid")]
        public int Birthday { get; set; }
    }
}
