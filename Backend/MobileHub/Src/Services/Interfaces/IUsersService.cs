using MobileHub.Src.DTO;

namespace MobileHub.Src.Services.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de usuarios.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Actualiza la información de un usuario.
        /// </summary>
        /// <param name="updateUserDto">
        /// DTO que contiene la información actualizada del usuario.
        /// </param>
        /// <param name="rut">
        /// Rut del usuario que se actualizará.
        /// </param>
        /// <returns>
        /// DTO que representa la información actualizada del usuario.
        /// </returns>
        public Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto, string rut);

        /// <summary>
        /// Obtiene la información de un usuario por su dirección de correo electrónico.
        /// </summary>
        /// <param name="email">
        /// Dirección de correo electrónico del usuario.
        /// </param>
        /// <returns>
        /// DTO que representa la información del usuario.
        /// </returns>
        public Task<GetUserDto> GetUserByEmail(string email);

        /// <summary>
        /// Obtiene la información de un usuario por su RUT.
        /// </summary>
        /// <param name="rut">
        /// RUT del usuario.
        /// </param>
        /// <returns>
        /// DTO que representa la información del usuario.
        /// </returns>
        public Task<GetUserDto> GetUserByRut(string rut);

        /// <summary>
        /// Verifica la existencia de un usuario por su dirección de correo electrónico.
        /// </summary>
        /// <param name="email">
        /// Dirección de correo electrónico del usuario.
        /// </param>
        /// <returns>
        /// True si el usuario existe, False en caso contrario.
        /// </returns>
        public Task<bool> CheckEmail(string email);
    }
}
