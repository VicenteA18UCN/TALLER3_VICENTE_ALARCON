using MobileHub.Src.Services.Interfaces;
using MobileHub.Src.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MobileHub.Src.DTO;
using MobileHub.Src.Util;
using DotNetEnv;
namespace MobileHub.Src.Services
{
    /// <summary>
    /// Clase que implementa la interfaz IAuthService y proporciona servicios relacionados con la autenticación.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly string _jwtSecret;
        private readonly IUsersRepository _usersRepository;
        private readonly IMappingService _mappingService;

        /// <summary>
        /// Constructor de la clase AuthService.
        /// </summary>
        /// <param name="config">Instancia de IConfiguration para la configuración.</param>
        /// <param name="usersRepository">Instancia de IUsersRepository para acceder a los usuarios.</param>
        /// <param name="mappingService">Instancia de IMappingService para realizar mapeos.</param>
        public AuthService(IConfiguration config, IUsersRepository usersRepository, IMappingService mappingService)
        {
            Env.Load();
            var token = Env.GetString("SECRET_KEY") ?? throw new ArgumentNullException("SECRET_KEY is null");
            _jwtSecret = token;
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        }

        /// <summary>
        /// Genera un token JWT para el usuario con el correo electrónico proporcionado.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <returns>Token JWT generado.</returns>
        public string? GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, email),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Verifica las credenciales del usuario.
        /// </summary>
        /// <param name="loginUserDto">DTO que contiene las credenciales del usuario.</param>
        /// <returns>True si las credenciales son válidas; de lo contrario, false.</returns>
        public async Task<bool> CheckCredentials(LoginUserDto loginUserDto)
        {
            if (string.IsNullOrEmpty(loginUserDto.Email) || string.IsNullOrEmpty(loginUserDto.Password))
            {
                return false;
            }

            var user = await _usersRepository.GetByEmail(loginUserDto.Email);
            if (user == null) return false;

            return BCryptHelper.CheckPassword(loginUserDto.Password, user.Password);
        }

        /// <summary>
        /// Registra un nuevo usuario con la información proporcionada.
        /// </summary>
        /// <param name="createUserDto">DTO que contiene la información del nuevo usuario.</param>
        /// <returns>DTO del usuario creado.</returns>
        public async Task<CreateUserDto?> Register(CreateUserDto createUserDto)
        {
            var rut = createUserDto.Rut.Replace(".", "").Replace("-", "");
            var password = rut.Substring(0, rut.Length - 1);
            createUserDto.Password = BCrypt.Net.BCrypt.HashPassword(password);

            var user = _mappingService.CreateClientDtoToUser(createUserDto);
            var createdUser = await _usersRepository.Add(user);
            var mappedDto = _mappingService.MapUserToCreateUserDto(createdUser);
            return mappedDto;
        }

        /// <summary>
        /// Actualiza la contraseña del usuario con la información proporcionada.
        /// </summary>
        /// <param name="updatePasswordDto">DTO que contiene la nueva contraseña.</param>
        /// <param name="userDto">DTO del usuario para actualizar la contraseña.</param>
        /// <returns>DTO del usuario actualizado.</returns>
        public async Task<GetUserDto?> UpdatePassword(UpdatePasswordDto updatePasswordDto, GetUserDto userDto)
        {
            var user = await _usersRepository.GetByEmail(userDto.Email);
            if (user == null) return null;
            var password = BCrypt.Net.BCrypt.HashPassword(updatePasswordDto.NewPassword);
            user.Password = password;
            var updatedUser = await _usersRepository.Update(user);
            var mappedDto = _mappingService.MapUserToGetUserDto(updatedUser);
            return mappedDto;
        }

        /// <summary>
        /// Obtiene un usuario por su Rut.
        /// </summary>
        /// <param name="rut">Rut del usuario a buscar.</param>
        /// <returns>DTO del usuario encontrado.</returns>
        public async Task<GetUserDto?> GetUserByRut(string rut)
        {
            var user = await _usersRepository.GetByRut(rut);
            if (user == null) return null;
            var mappedDto = _mappingService.MapUserToGetUserDto(user);
            return mappedDto;
        }

        /// <summary>
        /// Obtiene un usuario por su correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario a buscar.</param>
        /// <returns>DTO del usuario encontrado.</returns>
        public async Task<GetUserDto?> GetUserByEmail(string email)
        {
            var user = await _usersRepository.GetByEmail(email);
            if (user == null) return null;
            var mappedDto = _mappingService.MapUserToGetUserDto(user);
            return mappedDto;
        }
    }
}