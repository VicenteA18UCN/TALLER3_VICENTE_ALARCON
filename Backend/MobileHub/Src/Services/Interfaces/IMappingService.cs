using AutoMapper;
using MobileHub.Src.DTO;
using MobileHub.Src.DTO.Repos;
using MobileHub.Src.DTO.Users;
using MobileHub.Src.Models;

namespace MobileHub.Src.Services.Interfaces
{
    public interface IMappingService
    {
        public User CreateClientDtoToUser(CreateUserDto createUserDto);

        public CreateUserDto MapUserToCreateUserDto(User user);

        public GetUserDto MapUserToGetUserDto(User user);

        public User UpdateUserDtoToUser(User user, UpdateUserDto updateUserDto);
        public UpdateUserDto CreateUpdateUserDto(User user);
        public ReposDto MapRepositoryToReposDto(Octokit.Repository repository);

    }
}