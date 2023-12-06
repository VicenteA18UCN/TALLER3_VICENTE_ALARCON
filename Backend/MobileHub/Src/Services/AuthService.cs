using MobileHub.Src.Services.Interfaces;
using MobileHub.Src.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MobileHub.Src.DTO;
using MobileHub.Src.Util;
using MobileHub.Src.Models;
namespace MobileHub.Src.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _jwtSecret;
        private readonly IUsersRepository _usersRepository;
        public AuthService(IConfiguration config, IUsersRepository usersRepository)
        {
            var token = config.GetValue<string>("JwtSettings:Secret") ?? throw new ArgumentNullException("JwtSettings:Secret is null");
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
            return user;
        }

    }
}