using MobileHub.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace MobileHub.Src.Data
{

    public class DataContext : DbContext
    {
        /// <summary>
        ///   Users: Tabla de usuarios.
        /// </summary>
        /// 
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Representa el contexto de la base de datos.
        /// </summary>
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
