using MobileHub.Src.Data;
using System.Text;
using MobileHub.Src.Repositories;
using MobileHub.Src.Repositories.Interfaces;
using MobileHub.Src.Services;
using MobileHub.Src.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            AddRepositories(services);
            AddServices(services);
            AddAuthentication(services, config);
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


        /// <summary>
        /// Método para agregar los repositorios de la aplicación.
        /// </summary>
        /// <param name="services">
        /// - services: Servicios de la aplicación.
        /// </param>
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        /// <summary>
        /// Método para agregar los servicios de la aplicación.
        /// </summary>
        /// <param name="services">
        /// - services: Servicios de la aplicación.
        /// </param>
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }

        /// <summary>   
        /// Método para agregar la autenticación.
        /// </summary>
        /// <param name="services">
        /// - services: Servicios de la aplicación.
        /// </param>
        /// <param name="config">
        /// - config: Configuración de la aplicación.
        /// </param>
        private static IServiceCollection AddAuthentication(IServiceCollection services, IConfiguration config)
        {
            var jwtSecret = config["JwtSettings:Secret"] ?? throw new Exception("JwtSettings:Secret is null");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }

    }
}