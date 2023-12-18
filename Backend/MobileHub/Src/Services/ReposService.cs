using MobileHub.Src.Repositories.Interfaces;
using MobileHub.Src.Services.Interfaces;
using DotNetEnv;
using Octokit;
using MobileHub.Src.DTO.Repos;
using MobileHub.Src.DTO.Commits;


namespace MobileHub.Src.Services
{
    /// <summary>
    /// Clase que implementa la interfaz IReposService y proporciona servicios relacionados con la gestión de repositorios.
    /// </summary>
    public class ReposService : IReposService
    {
        private readonly string _githubToken;
        private readonly IReposRepository _reposRepository;
        private readonly IMappingService _mappingService;
        private readonly GitHubClient _client;

        /// <summary>
        /// Constructor de la clase ReposService.
        /// </summary>
        /// <param name="reposRepository">Instancia de la interfaz IReposRepository para acceder a operaciones de repositorio de GitHub.</param>
        /// <param name="mappingService">Instancia de la interfaz IMappingService para realizar mapeos entre objetos DTO y entidades de repositorio.</param>
        public ReposService(IReposRepository reposRepository, IMappingService mappingService)
        {
            Env.Load();
            _githubToken = Env.GetString("GITHUB_TOKEN") ?? throw new ArgumentNullException("GITHUB_TOKEN is null");
            _reposRepository = reposRepository ?? throw new ArgumentNullException(nameof(reposRepository));
            _mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            _client = ClientProvider();
        }

        /// <summary>
        /// Método para proporcionar una instancia de GitHubClient con la autenticación de token.
        /// </summary>
        /// <returns>Instancia de GitHubClient con la autenticación de token.</returns>
        private GitHubClient ClientProvider()
        {
            var client = new GitHubClient(new ProductHeaderValue("MobileHub"));
            var tokenCred = new Credentials(_githubToken);
            client.Credentials = tokenCred;
            return client;
        }

        /// <summary>
        /// Método para obtener la lista de todos los repositorios del usuario autenticado en GitHub.
        /// </summary>
        /// <returns>Lista de objetos DTO que representan la información de los repositorios.</returns>
        public async Task<IReadOnlyList<ReposDto>?> GetAllRepositories()
        {
            var repos = await _reposRepository.GetAllRepositories(_client);
            if (repos == null) return null;
            repos = repos.OrderByDescending(x => x.UpdatedAt).ToList();
            var reposDto = new List<ReposDto>();

            var getCommitsTasks = repos.Select(repo =>
            {
                if (repo.Size == 0)
                {
                    return _reposRepository.GetCommitsCountByRepositories(_client, "");
                }
                return _reposRepository.GetCommitsCountByRepositories(_client, repo.Name);
            }).ToList();

            var commitsResults = await Task.WhenAll(getCommitsTasks);

            for (int i = 0; i < repos.Count; i++)
            {
                var repoDto = _mappingService.MapRepositoryToReposDto(repos[i]);
                repoDto.CommitCount = commitsResults[i];
                reposDto.Add(repoDto);
            }

            return reposDto;
        }

        /// <summary>
        /// Método para obtener la lista de commits de un repositorio específico.
        /// </summary>
        /// <param name="repoName">Nombre del repositorio.</param>
        /// <returns>Lista de objetos DTO que representan la información de los commits.</returns>
        public async Task<IReadOnlyList<CommitDto>?> GetCommitsByRepositories(string repoName)
        {
            var commits = await _reposRepository.GetCommitsByRepositories(_client, repoName);
            if (commits == null) return null;
            commits = commits.OrderByDescending(x => x.Commit.Committer.Date).ToList();
            var commitsDto = new List<CommitDto>();
            foreach (var commit in commits)
            {
                var commitDto = _mappingService.MapCommitToCommitDto(commit);
                commitsDto.Add(commitDto);
            }
            return commitsDto;
        }
    }
}