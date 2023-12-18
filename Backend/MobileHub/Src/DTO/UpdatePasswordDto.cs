using System.ComponentModel.DataAnnotations;

namespace MobileHub.Src.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) para actualizar la contraseña de un usuario.
    /// </summary>
    public class UpdatePasswordDto
    {
        /// <summary>
        /// Obtiene o establece la contraseña actual del usuario.
        /// </summary>
        [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
        public string CurrentPassword { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la nueva contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La contraseña debe tener una longitud entre 6 y 15 caracteres.")]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la confirmación de la nueva contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "La confirmación de la nueva contraseña es obligatoria.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La contraseña debe tener una longitud entre 6 y 15 caracteres.")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
