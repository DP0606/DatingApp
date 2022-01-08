using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        //DTO je dobro mjesto za validacije!
        [Required] // Ovo je sad property!
        public string Username {get; set;}

        [Required]
        public string Password {get; set;}
    }
}