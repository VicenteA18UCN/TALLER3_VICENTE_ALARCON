using MobileHub.Src.DTO.Commits;
using MobileHub.Src.DTO.Repos;

namespace MobileHub.Src.Services.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de repositorios.
    /// </summary>
    public interface IReposService
    {
        /// <summary>
        /// Obtiene la lista de todos los repositorios.
        /// </summary>
        /// <returns>
        /// Lista de DTOs que representan la información de los repositorios o null si no hay repositorios.
        /// </returns>
        public Task<IReadOnlyList<ReposDto>?> GetAllRepositories();

        /// <summary>
        /// Obtiene la lista de commits para un repositorio específico.
        /// </summary>
        /// <param name="repoName">
        /// Nombre del repositorio para el cual se obtendrán los commits.
        /// </param>
        /// <returns>
        /// Lista de DTOs que representan la información de los commits o null si no hay commits o el repositorio no existe.
        /// </returns>
        public Task<IReadOnlyList<CommitDto>?> GetCommitsByRepositories(string repoName);
    }
}
