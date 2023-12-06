using MobileHub.Src.Models;

namespace MobileHub.Src.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Método para agregar un usuario.
        /// </summary>
        /// <param name="user">
        /// - user: Usuario a agregar.
        /// </param>
        /// <returns>
        /// Retorna el usuario agregado.
        /// </returns>
        public Task<User> Add(User user);
        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        /// <param name="user">
        /// - user: Usuario a actualizar.
        /// </param>
        /// <returns>
        /// Retorna el usuario actualizado.
        /// </returns>
        public Task<User> Update(User user);
        /// <summary>
        /// Método para eliminar un usuario.
        /// </summary>
        /// <param name="user">
        /// - user: Usuario a eliminar.
        /// </param>
        /// <returns>
        /// Retorna el usuario eliminado.
        /// </returns>
        public Task<User> Delete(User user);
        /// <summary>
        /// Método para obtener todos los usuarios. Excluye a los administradores.
        /// </summary>
        /// <returns>
        /// Retorna una lista con todos los usuarios.
        /// </returns>
        public Task<List<User>> GetAll();
        /// <summary>
        /// Método para obtener un usuario por su id.
        /// </summary>
        /// <param name="id">
        /// - id: Id del usuario a obtener.
        /// </param>
        /// <returns>
        /// Retorna el usuario obtenido.
        /// </returns>
        public Task<User?> GetById(int id);
        /// <summary>
        /// Método para obtener un usuario por su email.
        /// </summary>
        /// <param name="email">
        /// - email: Email del usuario a obtener.
        /// </param>
        /// <returns>
        /// Retorna el usuario obtenido.
        /// </returns> 
        public Task<User?> GetByEmail(string email);
        /// <summary>
        /// Método para obtener un usuario por su rut.
        /// </summary>
        /// <param name="rut">
        /// - rut: Rut del usuario a obtener.
        /// </param>
        /// <returns>
        /// Retorna el usuario obtenido.
        /// </returns>
        public Task<User?> GetByRut(string rut);
    }
}