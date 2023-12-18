using MobileHub.Src.Data;
using MobileHub.Src.Models;
using MobileHub.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MobileHub.Src.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de usuarios.
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        /// <summary>
        /// Contexto de la base de datos.
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Constructor de la clase UsersRepository.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega un usuario a la base de datos.
        /// </summary>
        /// <param name="user">Usuario a agregar.</param>
        /// <returns>El usuario agregado.</returns>
        public async Task<User> Add(User user)
        {
            var createdUser = (await _context.Users.AddAsync(user)).Entity;
            await _context.SaveChangesAsync();
            return createdUser;
        }

        /// <summary>
        /// Actualiza la información de un usuario en la base de datos.
        /// </summary>
        /// <param name="user">Usuario a actualizar.</param>
        /// <returns>El usuario actualizado.</returns>
        public async Task<User> Update(User user)
        {
            var updateUser = _context.Users.Update(user).Entity;
            await _context.SaveChangesAsync();
            return updateUser;
        }

        /// <summary>
        /// Elimina un usuario de la base de datos.
        /// </summary>
        /// <param name="user">Usuario a eliminar.</param>
        /// <returns>El usuario eliminado.</returns>
        public async Task<User> Delete(User user)
        {
            var deletedUser = _context.Users.Remove(user).Entity;
            await _context.SaveChangesAsync();
            return deletedUser;
        }

        /// <summary>
        /// Obtiene todos los usuarios de la base de datos, excluyendo a los administradores.
        /// </summary>
        /// <returns>Una lista con todos los usuarios.</returns>
        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a obtener.</param>
        /// <returns>El usuario obtenido.</returns>
        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        /// <summary>
        /// Obtiene un usuario por su dirección de correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario a obtener.</param>
        /// <returns>El usuario obtenido.</returns>
        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        /// <summary>
        /// Obtiene un usuario por su RUT.
        /// </summary>
        /// <param name="rut">RUT del usuario a obtener.</param>
        /// <returns>El usuario obtenido.</returns>
        public async Task<User?> GetByRut(string rut)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Rut == rut);
            return user;
        }
    }
}