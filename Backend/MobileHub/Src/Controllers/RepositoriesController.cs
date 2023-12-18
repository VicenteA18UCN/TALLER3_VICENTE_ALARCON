using Microsoft.AspNetCore.Mvc;

using Octokit;

using MobileHub.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MobileHub.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriesController : ControllerBase
    {

        private readonly IReposService _reposService;

        /// <summary>
        /// Constructor de la clase RepositoriesController.
        /// </summary>
        /// <param name="reposService">Servicio de repositorios.</param>
        public RepositoriesController(IReposService reposService)
        {
            _reposService = reposService ?? throw new ArgumentNullException(nameof(reposService));
        }

        /// <summary>
        /// Método para obtener todos los repositorios.
        /// </summary>
        /// <returns>
        /// Retorna una lista de repositorios en caso de que existan, con sus datos.
        /// En caso de que no existan, retorna un BadRequest, con el mensaje "Internal Server Error".
        /// </returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GitHubCommit>?>> GetRepos()
        {
            try
            {
                var repos = await _reposService.GetAllRepositories();
                return Ok(repos);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        /// Obtiene la lista de commits para un repositorio específico.
        /// </summary>
        /// <param name="repoName">Nombre del repositorio.</param>
        /// <returns>Lista de commits.</returns>
        [Authorize]
        [HttpGet("commits/{repoName}")]
        public async Task<ActionResult<IReadOnlyList<GitHubCommit>?>> GetCommitsByRepo(string repoName)
        {
            try
            {
                var commits = await _reposService.GetCommitsByRepositories(repoName);
                return Ok(commits);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
