using MobileHub.Src.DTO;
using MobileHub.Src.Repositories.Interfaces;
using MobileHub.Src.Services.Interfaces;

namespace MobileHub.Src.Services
{
    /// <summary>
    /// Clase que implementa la interfaz IUsersService y proporciona servicios relacionados con la gestión de usuarios.
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMappingService _mappingService;

        /// <summary>
        /// Constructor de la clase UsersService.
        /// </summary>
        /// <param name="usersRepository">Instancia de la interfaz IUsersRepository para acceder a operaciones de repositorio de usuarios.</param>
        /// <param name="mappingService">Instancia de la interfaz IMappingService para realizar mapeos entre objetos DTO y entidades de usuario.</param>
        public UsersService(IUsersRepository usersRepository, IMappingService mappingService)
        {
            _usersRepository = usersRepository;
            _mappingService = mappingService;
        }

        /// <summary>
        /// Método para actualizar la información de un usuario.
        /// </summary>
        /// <param name="updateUserDto">Objeto DTO con la información actualizada del usuario.</param>
        /// <param name="rut">RUT del usuario a actualizar.</param>
        /// <returns>Objeto DTO con la información actualizada del usuario.</returns>
        public async Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto, string rut)
        {
            var user = await _usersRepository.GetByRut(rut);
            if (user == null) throw new Exception("User not found");
            user = _mappingService.UpdateUserDtoToUser(user, updateUserDto);
            var updatedUser = await _usersRepository.Update(user);
            return _mappingService.CreateUpdateUserDto(updatedUser);
        }

        /// <summary>
        /// Método para obtener la información de un usuario por su RUT.
        /// </summary>
        /// <param name="rut">RUT del usuario a obtener.</param>
        /// <returns>Objeto DTO con la información del usuario.</returns>
        public async Task<GetUserDto> GetUserByRut(string rut)
        {
            var user = await _usersRepository.GetByRut(rut);
            if (user == null) throw new Exception("User not found");
            var mappedDto = _mappingService.MapUserToGetUserDto(user);
            return mappedDto;
        }

        /// <summary>
        /// Método para obtener la información de un usuario por su dirección de correo electrónico.
        /// </summary>
        /// <param name="email">Dirección de correo electrónico del usuario a obtener.</param>
        /// <returns>Objeto DTO con la información del usuario.</returns>
        public async Task<GetUserDto> GetUserByEmail(string email)
        {
            var user = await _usersRepository.GetByEmail(email);
            if (user == null) throw new Exception("User not found");
            var mappedDto = _mappingService.MapUserToGetUserDto(user);
            return mappedDto;
        }

        /// <summary>
        /// Método para verificar la existencia de un usuario por su dirección de correo electrónico.
        /// </summary>
        /// <param name="email">Dirección de correo electrónico del usuario a verificar.</param>
        /// <returns>True si el usuario existe; de lo contrario, false.</returns>
        public async Task<bool> CheckEmail(string email)
        {
            var user = await _usersRepository.GetByEmail(email);
            if (user == null) return false;
            return true;
        }
    }
}
