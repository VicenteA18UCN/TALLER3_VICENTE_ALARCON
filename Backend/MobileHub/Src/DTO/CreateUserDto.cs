using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileHub.Src.DTO
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(150, ErrorMessage = "El nombre no puede tener más de 150 caracteres")]
        [MinLength(10, ErrorMessage = "El nombre no puede tener menos de 10 caracteres")]
        public string Fullname { get; set; } = string.Empty;
        [Required(ErrorMessage = "El rut es requerido")]
        public string Rut { get; set; } = string.Empty;
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El cumpleaños es requerido")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; } = DateTime.Now;

    }
}