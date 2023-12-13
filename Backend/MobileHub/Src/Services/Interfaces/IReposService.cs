using MobileHub.Src.DTO.Commits;
using MobileHub.Src.DTO.Repos;
using Octokit;
namespace MobileHub.Src.Services.Interfaces
{
    public interface IReposService
    {
        public Task<IReadOnlyList<ReposDto>?> GetAllRepositories();
        public Task<IReadOnlyList<CommitDto>?> GetCommitsByRepositories(string repoName);
    }
}