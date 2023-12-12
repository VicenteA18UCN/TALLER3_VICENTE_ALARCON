
using System.ComponentModel.DataAnnotations;

using MobileHub.Src.DataAnnotations;

namespace MobileHub.Src.DTO
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "The fullname is required")]
        public string Fullname { get; set; } = string.Empty;
        [UCNEmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The age birthday is required")]
        [BirthdateRange(ErrorMessage = "The age birthday is not valid")]
        public int Birthday { get; set; }
    }
}