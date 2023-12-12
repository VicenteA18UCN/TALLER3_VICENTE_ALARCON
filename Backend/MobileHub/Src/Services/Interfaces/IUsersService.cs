using MobileHub.Src.DTO;

namespace MobileHub.Src.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto, string rut);


        /// <summary>
        /// Método para obtener un usuario por su email.
        /// </summary>
        /// <param name="rut">
        /// - email: Email del usuario a obtener.
        /// </param>
        public Task<GetUserDto> GetUser(string rut);

        public Task<bool> CheckEmail(string email);

    }
}