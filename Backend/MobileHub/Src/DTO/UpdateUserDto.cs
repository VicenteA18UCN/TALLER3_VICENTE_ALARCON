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
        [MaxLength(150, ErrorMessage = "El nombre completo debe tener menos de 150 caracteres.")]
        [MinLength(10, ErrorMessage = "El nombre completo debe tener al menos 10 caracteres.")]
        public string Fullname { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        [UCNEmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del usuario.
        /// </summary>
        [BirthdateRange(ErrorMessage = "La fecha de nacimiento no es válida.")]
        public int Birthday { get; set; }
    }
}
