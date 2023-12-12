using MobileHub.Src.DTO;
using MobileHub.Src.Data;
using MobileHub.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileHub.Src.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MobileHub.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Método para obtener un usuario por su email.
        /// </summary>
        /// <param name="email">
        /// - email: Email del usuario a obtener.
        /// </param>
        /// <returns>
        /// Retorna un usuario en caso de que exista, con sus datos.
        /// En caso de que el usuario no exista, retorna un BadRequest, con el mensaje "User not found".
        /// </returns>
        /// <response code="200">Retorna un usuario en caso de que exista, con sus datos.</response>
        /// <response code="400">En caso de que el usuario no exista, retorna un BadRequest, con el mensaje "User not found".</response>
        /// <response code="500">En caso de que ocurra un error, retorna un InternalServerError, con el mensaje "Internal Server Error".</response>
        [HttpGet("{rut}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserDto>> GetUser(string rut)
        {
            try
            {
                var user = await _usersService.GetUserByRut(rut);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        /// <param name="updateUserDto">
        /// - updateUserDto: Objeto con los datos del usuario a actualizar.
        /// </param>
        /// <returns>
        /// Retorna un usuario en caso de que exista, con sus datos actualizados.
        /// En caso de que el usuario no exista, retorna un BadRequest, con el mensaje "User not found".
        /// </returns>
        /// <response code="200">Retorna un usuario en caso de que exista, con sus datos actualizados.</response>
        /// <response code="400">En caso de que el usuario no exista, retorna un BadRequest, con el mensaje "User not found".</response>
        /// <response code="500">En caso de que ocurra un error, retorna un InternalServerError, con el mensaje "Internal Server Error".</response>

        [HttpPut("{rut}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateUserDto>> UpdateUser(UpdateUserDto updateUserDto, string rut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _usersService.GetUserByRut(rut);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var existsEmail = await _usersService.CheckEmail(updateUserDto.Email);
            if (existsEmail && user.Email != updateUserDto.Email)
            {
                return BadRequest("Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _usersService.UpdateUser(updateUserDto, rut);
        }

    }
}