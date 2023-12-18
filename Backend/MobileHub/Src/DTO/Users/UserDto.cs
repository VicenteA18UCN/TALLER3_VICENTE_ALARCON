using System;

namespace MobileHub.Src.DTO.Users
{
    /// <summary>
    /// Data Transfer Object (DTO) para representar la información de un usuario.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Obtiene o establece el identificador único del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del usuario.
        /// </summary>
        public string Fullname { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el RUT (Rol Único Tributario) del usuario.
        /// </summary>
        public string Rut { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico del usuario.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del usuario.
        /// </summary>
        public int Birthday { get; set; }
    }
}
