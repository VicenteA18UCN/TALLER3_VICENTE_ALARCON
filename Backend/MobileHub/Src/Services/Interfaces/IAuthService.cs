using MobileHub.Src.DTO;

namespace MobileHub.Src.Services.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de autenticación.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Genera un token con el email del usuario.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <returns>Token generado.</returns>
        public string? GenerateToken(string email);

        /// <summary>
        /// Verifica las credenciales del usuario.
        /// </summary>
        /// <param name="loginUserDto">DTO que contiene las credenciales del usuario.</param>
        /// <returns>True si las credenciales son válidas; de lo contrario, false.</returns>
        public Task<bool> CheckCredentials(LoginUserDto loginUserDto);

        /// <summary>
        /// Obtiene un usuario por su correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario a buscar.</param>
        /// <returns>DTO del usuario encontrado.</returns>
        public Task<GetUserDto?> GetUserByEmail(string email);

        /// <summary>
        /// Obtiene un usuario por su Rut.
        /// </summary>
        /// <param name="rut">Rut del usuario a buscar.</param>
        /// <returns>DTO del usuario encontrado.</returns>
        public Task<GetUserDto?> GetUserByRut(string rut);

        /// <summary>
        /// Registra un nuevo usuario con la información proporcionada.
        /// </summary>
        /// <param name="createUserDto">DTO que contiene la información del nuevo usuario.</param>
        /// <returns>DTO del usuario creado.</returns>
        public Task<CreateUserDto?> Register(CreateUserDto createUserDto);

        /// <summary>
        /// Actualiza la contraseña del usuario con la información proporcionada.
        /// </summary>
        /// <param name="updatePasswordDto">DTO que contiene la nueva contraseña.</param>
        /// <param name="userDto">DTO del usuario para actualizar la contraseña.</param>
        /// <returns>DTO del usuario actualizado.</returns>
        public Task<GetUserDto?> UpdatePassword(UpdatePasswordDto updatePasswordDto, GetUserDto userDto);
    }
}
