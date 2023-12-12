using System.ComponentModel.DataAnnotations;
using MobileHub.Src.DataAnnotations;

namespace MobileHub.Src.DTO
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "The password is required")]
        [MaxLength(150, ErrorMessage = "The password must be less than 150 characters")]
        [MinLength(10, ErrorMessage = "The password must be at least 10 characters")]
        public string Fullname { get; set; } = string.Empty;
        [Required(ErrorMessage = "The rut is required")]
        [Rut(ErrorMessage = "The rut is not valid")]
        public string Rut { get; set; } = string.Empty;
        [Required(ErrorMessage = "The email is required")]
        [UCNEmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "The birthday is required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; } = DateTime.Now;

        public string Password { get; set; } = string.Empty;

    }
}