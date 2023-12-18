using System;

namespace MobileHub.Src.DTO.Repos
{
    /// <summary>
    /// Data Transfer Object (DTO) para representar la información de un repositorio.
    /// </summary>
    public class ReposDto
    {
        /// <summary>
        /// Obtiene o establece el nombre del repositorio.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la fecha y hora de la última actualización del repositorio.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Obtiene o establece la fecha y hora de creación del repositorio.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Obtiene o establece la cantidad de commits en el repositorio.
        /// </summary>
        public int CommitCount { get; set; } = 0;
    }
}
