using MobileHub.Src.DTO;
using MobileHub.Src.Data;
using MobileHub.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileHub.Src.Services.Interfaces;

namespace MobileHub.Src.Controllers
{
    // Controlador para la autenticación.
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Atributos:
        ///    - _authService: Servicio de autenticación.
        /// </summary>
        private readonly IAuthService _authService;

        //Constructor:
        public AuthController(IAuthService authService)
        {

            _authService = authService;

        }

        /// <summary>
        /// Método para autenticar un administrador. En caso de que sea válido, se genera un token con el rut del administrador.
        /// </summary>
        /// <param name="loginUserDto">
        ///    - Username: Nombre de usuario del administrador.
        ///    - Password: Contraseña del administrador.
        /// </param>
        /// <returns>
        /// Retorna un token en caso de que sea válido, con el rut del administrador.
        /// En caso de las credenciales no correspondan, retorna un BadRequest, con el mensaje "Invalid Credentials".
        /// En caso de que el administrador no exista, retorna un BadRequest, con el mensaje "Invalid Credentials".
        /// En caso de que el usuario no exista, retorna un BadRequest, con el mensaje "Invalid Credentials".
        /// En caso de que el token no se genere correctamente, retorna un BadRequest, con el mensaje "Token error". 
        /// </returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto loginUserDto)
        {
            var checkCredentials = await _authService.CheckCredentials(loginUserDto);
            if (!checkCredentials) return BadRequest("Invalid Credentials");

            var user = await _authService.GetUser(loginUserDto.Email);
            if (user == null) return BadRequest("Invalid Credentials");

            var token = _authService.GenerateToken(user.Email);
            if (string.IsNullOrEmpty(token)) return BadRequest("Token error");

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(CreateUserDto createUserDto)
        {
            if (string.IsNullOrEmpty(createUserDto.Email) || string.IsNullOrEmpty(createUserDto.Rut) || string.IsNullOrEmpty(createUserDto.Fullname))
            {
                return BadRequest("Empty fields");
            }

            createUserDto.Rut = createUserDto.Rut.ToUpper();

            if (!_authService.CheckRut(createUserDto.Rut))
            {
                return BadRequest("Invalid rut");
            }

            if (!_authService.CheckEmail(createUserDto.Email))
            {
                return BadRequest("Invalid email");
            }

            if (!_authService.CheckBirthday(createUserDto.Birthday))
            {
                return BadRequest("Invalid birthday");
            }

            var user = await _authService.GetUser(createUserDto.Email);
            if (user != null) return BadRequest("User already exists");

            var createdUser = await _authService.Register(createUserDto);
            if (createdUser == null) return BadRequest("Error creating user");

            var token = _authService.GenerateToken(createdUser.Email);
            if (string.IsNullOrEmpty(token)) return BadRequest("Token error");

            return Ok(new { Token = token });
        }

    }
}