using AutoMapper;
using MobileHub.Src.DTO;
using MobileHub.Src.DTO.Users;
using MobileHub.Src.Models;
using MobileHub.Src.Services.Interfaces;


namespace MobileHub.Src.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMapper _mapper;

        public MappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User CreateClientDtoToUser(CreateUserDto createUserDto)
        {
            return _mapper.Map<User>(createUserDto);
        }

        public CreateUserDto MapUserToCreateUserDto(User user)
        {
            return _mapper.Map<CreateUserDto>(user);
        }

        public GetUserDto MapUserToGetUserDto(User user)
        {
            return _mapper.Map<GetUserDto>(user);
        }

        public User UpdateUserDtoToUser(User user, UpdateUserDto updateUserDto)
        {
            return _mapper.Map(updateUserDto, user);
        }

        public UpdateUserDto CreateUpdateUserDto(User user)
        {
            return _mapper.Map<UpdateUserDto>(user);
        }

    }
}