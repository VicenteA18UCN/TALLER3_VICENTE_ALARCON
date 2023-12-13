using Octokit;
namespace MobileHub.Src.Repositories.Interfaces
{
    public interface IReposRepository
    {
        public Task<IReadOnlyList<Repository>?> GetAllRepositories(GitHubClient client);
        public Task<IReadOnlyList<GitHubCommit>?> GetCommitsByRepositories(GitHubClient client, string repoName);
        public Task<int> GetCommitsCountByRepositories(GitHubClient client, string repoName);
    }

}