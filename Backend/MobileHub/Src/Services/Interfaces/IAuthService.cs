using MobileHub.Src.DTO;
using MobileHub.Src.Models;
using Microsoft.AspNetCore.Authorization;
using MobileHub.Src.DTO.Users;

namespace MobileHub.Src.Services.Interfaces
{
    // Interfaz para el servicio de autenticación.
    public interface IAuthService
    {
        /// <summary>
        ///  Método para generar un token. Genera un token con el email.
        /// </summary>
        /// <param name="email">
        /// - Email: email del usuario.
        /// </param>
        /// <returns>
        /// Retorna el token generado.
        /// </returns>
        public string? GenerateToken(string email);
        /// <summary>
        /// Método para verificar las credenciales de un administrador.
        /// </summary>
        /// <param name="loginAdminDto">
        /// - loginAdminDto: Objeto con las credenciales del administrador.
        /// </param>
        /// <returns>
        /// Retorna true si las credenciales son válidas, false en caso contrario.
        /// </returns>
        public Task<bool> CheckCredentials(LoginUserDto loginUserDto);

        public Task<GetUserDto?> GetUserByEmail(string email);

        public Task<GetUserDto?> GetUserByRut(string rut);

        public Task<CreateUserDto?> Register(CreateUserDto createUserDto);

        public Task<GetUserDto?> UpdatePassword(UpdatePasswordDto updatePasswordDto, GetUserDto userDto);

    }
}