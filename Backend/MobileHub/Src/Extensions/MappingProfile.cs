using AutoMapper;
using MobileHub.Src.DTO.Users;
using MobileHub.Src.DTO.Repos;
using MobileHub.Src.DTO.Commits;
using MobileHub.Src.DTO;
using MobileHub.Src.Models;

namespace MobileHub.Src.Extensions
{
    /// <summary>
    /// Perfil de mapeo para AutoMapper que define cómo mapear entre entidades y DTOs.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor que configura los mapeos entre entidades y DTOs.
        /// </summary>
        public MappingProfile()
        {
            // Mapeo de User a UserDto
            CreateMap<User, UserDto>();

            // Mapeo de User a CreateUserDto y viceversa
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();

            // Mapeo de User a GetUserDto
            CreateMap<User, GetUserDto>();

            // Mapeo de User a UpdateUserDto y viceversa
            CreateMap<User, UpdateUserDto>();
            CreateMap<UpdateUserDto, User>();

            // Mapeo de Octokit.Repository a ReposDto
            CreateMap<Octokit.Repository, ReposDto>();

            // Mapeo de Octokit.GitHubCommit a CommitDto con opciones específicas
            CreateMap<Octokit.GitHubCommit, CommitDto>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Commit.Message))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Commit.Author.Name))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Commit.Author.Date))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Author.Login))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Author.AvatarUrl));
        }
    }
}
