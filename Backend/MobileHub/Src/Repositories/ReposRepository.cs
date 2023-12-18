using Octokit;
using MobileHub.Src.Repositories.Interfaces;

namespace MobileHub.Src.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de repositorios.
    /// </summary>
    public class ReposRepository : IReposRepository
    {
        /// <summary>
        /// Constructor de la clase ReposRepository.
        /// </summary>
        public ReposRepository()
        {
        }

        /// <summary>
        /// Obtiene todos los repositorios para un usuario en GitHub.
        /// </summary>
        /// <param name="client">Cliente de GitHub.</param>
        /// <returns>Una lista de repositorios ordenados por la fecha de actualización descendente.</returns>
        public async Task<IReadOnlyList<Repository>?> GetAllRepositories(GitHubClient client)
        {
            var repos = await client.Repository.GetAllForUser("Dizkm8");
            repos = repos.OrderByDescending(x => x.UpdatedAt).ToList();
            return repos;
        }

        /// <summary>
        /// Obtiene la lista de commits para un repositorio en GitHub.
        /// </summary>
        /// <param name="client">Cliente de GitHub.</param>
        /// <param name="repoName">Nombre del repositorio.</param>
        /// <returns>Una lista de commits.</returns>
        public async Task<IReadOnlyList<GitHubCommit>?> GetCommitsByRepositories(GitHubClient client, string repoName)
        {
            var commits = (await client.Repository.Commit.GetAll("Dizkm8", repoName)).ToList();
            return commits;
        }

        /// <summary>
        /// Obtiene el número de commits para un repositorio en GitHub.
        /// </summary>
        /// <param name="client">Cliente de GitHub.</param>
        /// <param name="repoName">Nombre del repositorio.</param>
        /// <returns>El número de commits.</returns>
        public async Task<int> GetCommitsCountByRepositories(GitHubClient client, string repoName)
        {
            var commits = (await client.Repository.Commit.GetAll("Dizkm8", repoName)).ToList();
            return commits.Count;
        }
    }
}
