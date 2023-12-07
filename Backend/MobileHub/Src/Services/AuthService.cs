using MobileHub.Src.Services.Interfaces;
using MobileHub.Src.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MobileHub.Src.DTO;
using MobileHub.Src.Util;
using MobileHub.Src.Models;
using DotNetEnv;
using System.Text.RegularExpressions;
namespace MobileHub.Src.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _jwtSecret;
        private readonly IUsersRepository _usersRepository;
        public AuthService(IConfiguration config, IUsersRepository usersRepository)
        {
            Env.Load();
            var token = Env.GetString("SECRET_KEY") ?? throw new ArgumentNullException("SECRET_KEY is null");
            _jwtSecret = token;
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public string? GenerateToken(string email, int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Name, email),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

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

        public async Task<User?> GetUser(string email)
        {
            var user = await _usersRepository.GetByEmail(email);
            if (user == null) return null;
            return user;
        }

        public async Task<User?> Register(CreateUserDto createUserDto)
        {


            var rut = createUserDto.Rut.Replace(".", "").Replace("-", "");
            var password = rut.Substring(0, rut.Length - 1);

            var newUser = new User
            {
                Email = createUserDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Fullname = createUserDto.Fullname,
                Rut = createUserDto.Rut,
                Birthday = createUserDto.Birthday
            };

            var result = await _usersRepository.Add(newUser);
            return result;
        }

        public bool CheckRut(string rut)
        {
            if (string.IsNullOrEmpty(rut)) return false;
            return RutValidator.IsValid(rut);
        }

        public bool CheckBirthday(DateTime birthday)
        {
            if (birthday > DateTime.Now) return false;
            return true;
        }

        public bool CheckEmail(string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@(?:ucn\.cl|alumnos\.ucn\.cl|disc\.ucn\.cl|ce\.ucn\.cl)$");
            return emailRegex.IsMatch(email);
        }
    }
}