using System;

namespace MobileHub.Src.DTO.Commits
{
    /// <summary>
    /// Data Transfer Object (DTO) para representar la información de un commit.
    /// </summary>
    public class CommitDto
    {
        /// <summary>
        /// Obtiene o establece el mensaje asociado al commit.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre asociado al commit.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora del commit.
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario asociado al commit.
        /// </summary>
        public string? User { get; set; }

        /// <summary>
        /// Obtiene o establece la URL del avatar asociado al usuario del commit.
        /// </summary>
        public string? AvatarUrl { get; set; }
    }
}
