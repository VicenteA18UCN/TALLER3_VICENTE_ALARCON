using Microsoft.AspNetCore.Mvc;
using DotNetEnv;
using Octokit;
using MobileHub.Src.Repositories.Interfaces;
using MobileHub.Src.Services.Interfaces;

namespace MobileHub.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriesController : ControllerBase
    {
        private readonly IReposService _reposService;

        public RepositoriesController(IReposService reposService)
        {
            _reposService = reposService ?? throw new ArgumentNullException(nameof(reposService));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GitHubCommit>?>> GetRepos()
        {
            var repos = await _reposService.GetAllRepositories();
            return Ok(repos);
        }

        [HttpGet("commits/{repoName}")]
        public async Task<ActionResult<IReadOnlyList<GitHubCommit>?>> GetCommitsByRepo(string repoName)
        {
            var commits = await _reposService.GetCommitsByRepositories(repoName);
            return Ok(commits);
        }

    }
}
