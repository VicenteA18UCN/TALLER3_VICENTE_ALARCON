using MobileHub.Src.Repositories.Interfaces;
using MobileHub.Src.Services.Interfaces;
using DotNetEnv;
using Octokit;
using MobileHub.Src.DTO.Repos;


namespace MobileHub.Src.Services
{
    public class ReposService : IReposService
    {
        private readonly string _githubToken;
        private readonly IReposRepository _reposRepository;
        private readonly IMappingService _mappingService;
        private readonly GitHubClient _client;
        public ReposService(IReposRepository reposRepository, IMappingService mappingService)
        {
            Env.Load();
            _githubToken = Env.GetString("GITHUB_TOKEN") ?? throw new ArgumentNullException("GITHUB_TOKEN is null");
            _reposRepository = reposRepository ?? throw new ArgumentNullException(nameof(reposRepository));
            _mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            _client = ClientProvider();
        }

        private GitHubClient ClientProvider()
        {
            var client = new GitHubClient(new ProductHeaderValue("MobileHub"));
            var tokenCred = new Credentials(_githubToken);
            client.Credentials = tokenCred;
            return client;
        }

        public async Task<IReadOnlyList<ReposDto>?> GetAllRepositories()
        {
            var repos = await _reposRepository.GetAllRepositories(_client);
            if (repos == null) return null;
            repos = repos.OrderByDescending(x => x.UpdatedAt).ToList();
            var reposDto = new List<ReposDto>();
            foreach (var repo in repos)
            {
                var repoDto = _mappingService.MapRepositoryToReposDto(repo);
                reposDto.Add(repoDto);
            }
            return reposDto;
        }

        public async Task<IReadOnlyList<GitHubCommit>?> GetCommitsByRepositories(string repoName)
        {
            var commits = await _reposRepository.GetCommitsByRepositories(_client, repoName);
            return commits;
        }

    }
}