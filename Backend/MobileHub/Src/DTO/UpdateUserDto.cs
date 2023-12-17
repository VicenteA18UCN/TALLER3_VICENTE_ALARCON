
using System.ComponentModel.DataAnnotations;

using MobileHub.Src.DataAnnotations;

namespace MobileHub.Src.DTO
{
    public class UpdateUserDto
    {
        [MaxLength(150, ErrorMessage = "The fullname must be less than 150 characters")]
        [MinLength(10, ErrorMessage = "The fullname must be at least 10 characters")]
        public string Fullname { get; set; } = string.Empty;
        [UCNEmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;

        [BirthdateRange(ErrorMessage = "The age birthday is not valid")]
        public int Birthday { get; set; }
    }
}