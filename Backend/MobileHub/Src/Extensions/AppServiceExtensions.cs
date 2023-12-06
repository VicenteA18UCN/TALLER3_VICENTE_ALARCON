using MobileHub.Src.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MobileHub.Src.Extensions
{
    // Extensión para agregar los servicios de la aplicación.
    public static class AppServiceExtensions
    {
        /// <summary>
        /// Método para agregar los servicios de la aplicación.
        /// </summary>
        /// <param name="services">
        /// - services: Servicios de la aplicación.
        /// </param>
        /// <param name="config">
        /// - config: Configuración de la aplicación.
        /// </param>
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            AddSwaggerGen(services);
            AddDbContext(services);

        }

        /// <summary>
        /// Método para agregar los servicios de swagger.
        /// </summary>
        /// <param name="services">
        /// - services: Servicios de la aplicación.
        /// </param>
        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Método para agregar el contexto de la base de datos.
        /// </summary>
        /// <param name="services">
        /// - services: Servicios de la aplicación.
        /// </param> 
        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlite("Data Source=MobileHub.db"));
        }
    }
}