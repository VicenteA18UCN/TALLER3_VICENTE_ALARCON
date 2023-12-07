using MobileHub.Src.DTO;
using MobileHub.Src.Models;
using Microsoft.AspNetCore.Authorization;

namespace MobileHub.Src.Services.Interfaces
{
    // Interfaz para el servicio de autenticación.
    public interface IAuthService
    {
        /// <summary>
        ///  Método para generar un token. Genera un token con el rut y el id del administrador.
        /// </summary>
        /// <param name="username">
        /// - rut: Rut del administrador.
        /// </param>
        /// <param name="id">
        /// - id: Id del administrador.
        /// </param>
        /// <returns>
        /// Retorna el token generado.
        /// </returns>
        public string? GenerateToken(string email, int id);
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

        /// <summary>
        /// Método para obtener un usuario por su email.
        /// </summary>
        /// <param name="email">
        /// - email: Email del usuario a obtener.
        /// </param>
        public Task<User?> GetUser(string email);

        public Task<User?> Register(CreateUserDto createUserDto);

        public bool CheckRut(string rut);
        public bool CheckBirthday(DateTime birthdate);
        public bool CheckEmail(string email);
    }
}