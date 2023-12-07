using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileHub.Src.DTO
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; } = string.Empty;
    }
}