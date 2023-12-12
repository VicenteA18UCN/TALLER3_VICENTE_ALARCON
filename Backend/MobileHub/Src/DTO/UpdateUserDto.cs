using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MobileHub.Src.DataAnnotations;

namespace MobileHub.Src.DTO
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "The fullname is required")]
        public string Fullname { get; set; } = string.Empty;
        [UCNEmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The birthday is required")]
        public DateTime Birthday { get; set; } = DateTime.Now;
    }
}