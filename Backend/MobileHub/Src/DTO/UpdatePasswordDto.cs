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
        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la nueva contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "New password is required")]

        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la confirmación de la nueva contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "Confirm new Password is required")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
