using Octokit;

namespace MobileHub.Src.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de gestión de repositorios.
    /// </summary>
    public interface IReposRepository
    {
        /// <summary>
        /// Obtiene todos los repositorios para un usuario en GitHub.
        /// </summary>
        /// <param name="client">Cliente de GitHub.</param>
        /// <returns>Una lista de repositorios ordenados por la fecha de actualización descendente.</returns>
        public Task<IReadOnlyList<Repository>?> GetAllRepositories(GitHubClient client);

        /// <summary>
        /// Obtiene la lista de commits para un repositorio en GitHub.
        /// </summary>
        /// <param name="client">Cliente de GitHub.</param>
        /// <param name="repoName">Nombre del repositorio.</param>
        /// <returns>Una lista de commits.</returns>
        public Task<IReadOnlyList<GitHubCommit>?> GetCommitsByRepositories(GitHubClient client, string repoName);

        /// <summary>
        /// Obtiene el número de commits para un repositorio en GitHub.
        /// </summary>
        /// <param name="client">Cliente de GitHub.</param>
        /// <param name="repoName">Nombre del repositorio.</param>
        /// <returns>El número de commits.</returns>
        public Task<int> GetCommitsCountByRepositories(GitHubClient client, string repoName);
    }
}
