using AutoMapper;
using MobileHub.Src.DTO;
using MobileHub.Src.DTO.Commits;
using MobileHub.Src.DTO.Repos;
using MobileHub.Src.Models;
using MobileHub.Src.Services.Interfaces;

namespace MobileHub.Src.Services
{
    /// <summary>
    /// Clase que implementa la interfaz IMappingService y proporciona métodos para realizar mapeos entre objetos DTO y entidades.
    /// </summary>
    public class MappingService : IMappingService
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase MappingService.
        /// </summary>
        /// <param name="mapper">Instancia de IMapper para realizar los mapeos.</param>
        public MappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Método para mapear un objeto CreateClientDto a un objeto User.
        /// </summary>
        /// <param name="createUserDto">Objeto CreateClientDto a ser mapeado.</param>
        /// <returns>Objeto User mapeado.</returns>
        public User CreateClientDtoToUser(CreateUserDto createUserDto)
        {
            return _mapper.Map<User>(createUserDto);
        }

        /// <summary>
        /// Método para mapear un objeto User a un objeto CreateUserDto.
        /// </summary>
        /// <param name="user">Objeto User a ser mapeado.</param>
        /// <returns>Objeto CreateUserDto mapeado.</returns>
        public CreateUserDto MapUserToCreateUserDto(User user)
        {
            return _mapper.Map<CreateUserDto>(user);
        }

        /// <summary>
        /// Método para mapear un objeto User a un objeto GetUserDto.
        /// </summary>
        /// <param name="user">Objeto User a ser mapeado.</param>
        /// <returns>Objeto GetUserDto mapeado.</returns>
        public GetUserDto MapUserToGetUserDto(User user)
        {
            return _mapper.Map<GetUserDto>(user);
        }

        /// <summary>
        /// Método para mapear un objeto UpdateUserDto a un objeto User.
        /// </summary>
        /// <param name="user">Objeto User a ser actualizado.</param>
        /// <param name="updateUserDto">Objeto UpdateUserDto con la información de actualización.</param>
        /// <returns>Objeto User actualizado.</returns>
        public User UpdateUserDtoToUser(User user, UpdateUserDto updateUserDto)
        {
            return _mapper.Map(updateUserDto, user);
        }

        /// <summary>
        /// Método para mapear un objeto User a un objeto UpdateUserDto.
        /// </summary>
        /// <param name="user">Objeto User a ser mapeado.</param>
        /// <returns>Objeto UpdateUserDto mapeado.</returns>
        public UpdateUserDto CreateUpdateUserDto(User user)
        {
            return _mapper.Map<UpdateUserDto>(user);
        }

        /// <summary>
        /// Método para mapear un objeto Repository a un objeto ReposDto.
        /// </summary>
        /// <param name="repository">Objeto Repository a ser mapeado.</param>
        /// <returns>Objeto ReposDto mapeado.</returns>
        public ReposDto MapRepositoryToReposDto(Octokit.Repository repository)
        {
            return _mapper.Map<ReposDto>(repository);
        }

        /// <summary>
        /// Método para mapear un objeto GitHubCommit a un objeto CommitDto.
        /// </summary>
        /// <param name="commit">Objeto GitHubCommit a ser mapeado.</param>
        /// <returns>Objeto CommitDto mapeado.</returns>
        public CommitDto MapCommitToCommitDto(Octokit.GitHubCommit commit)
        {
            return _mapper.Map<CommitDto>(commit);
        }
    }
}