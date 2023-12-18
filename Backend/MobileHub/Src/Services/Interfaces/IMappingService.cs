using MobileHub.Src.DTO;
using MobileHub.Src.DTO.Commits;
using MobileHub.Src.DTO.Repos;
using MobileHub.Src.Models;

namespace MobileHub.Src.Services.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de mapeo entre entidades y DTOs.
    /// </summary>
    public interface IMappingService
    {
        /// <summary>
        /// Convierte un DTO de creación de usuario a la entidad de usuario correspondiente.
        /// </summary>
        public User CreateClientDtoToUser(CreateUserDto createUserDto);

        /// <summary>
        /// Mapea un objeto de usuario a un DTO de creación de usuario.
        /// </summary>
        public CreateUserDto MapUserToCreateUserDto(User user);

        /// <summary>
        /// Mapea un objeto de usuario a un DTO de información de usuario.
        /// </summary>
        public GetUserDto MapUserToGetUserDto(User user);

        /// <summary>
        /// Actualiza un objeto de usuario con la información proporcionada en un DTO de actualización de usuario.
        /// </summary>
        public User UpdateUserDtoToUser(User user, UpdateUserDto updateUserDto);

        /// <summary>
        /// Crea un DTO de actualización de usuario a partir de un objeto de usuario.
        /// </summary>
        public UpdateUserDto CreateUpdateUserDto(User user);

        /// <summary>
        /// Mapea un objeto de repositorio de GitHub a un DTO correspondiente.
        /// </summary>
        public ReposDto MapRepositoryToReposDto(Octokit.Repository repository);

        /// <summary>
        /// Mapea un objeto de commit de GitHub a un DTO correspondiente.
        /// </summary>
        public CommitDto MapCommitToCommitDto(Octokit.GitHubCommit commit);
    }
}
