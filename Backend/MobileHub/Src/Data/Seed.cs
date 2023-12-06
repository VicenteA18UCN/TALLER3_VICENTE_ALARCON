using MobileHub.Src.Models;

namespace MobileHub.Src.Data
{
    public class Seed
    {
        /// <summary>
        /// Metodo que se encarga de poblar la base de datos con datos de prueba.
        /// </summary>
        /// <param name="context">
        /// - context: Contexto de la base de datos.
        /// </param>
        public async static void SeedData(DataContext context)
        {
            await SeedUsers(context);
        }

        /// <summary>
        /// Metodo que se encarga de poblar la base de datos con usuarios.	
        /// </summary>
        /// <param name="context">
        /// - context: Contexto de la base de datos.
        /// </param>
        /// <returns>
        /// Añaade a la base de datos los usuarios.
        /// </returns>
        private async static Task SeedUsers(DataContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>(){
                new(){
                    Fullname= "David Nahum Araya Cádiz",
                    Email = "david.araya@alumnos.ucn.cl",
                    Password = BCrypt.Net.BCrypt.HashPassword("20767691"),
                    Rut =  "20.767.691-8",
                    Birthday = new DateTime(2001, 04, 30),
                },
                new(){
                    Fullname= "Vicente Ignacio Alarcón Campillay",
                    Email = "vicente.alarcon@alumnos.ucn.cl",
                    Password = BCrypt.Net.BCrypt.HashPassword("21177605"),
                    Rut =  "21.177.605-6",
                    Birthday = new DateTime(2002, 11, 18),
                },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }

}
