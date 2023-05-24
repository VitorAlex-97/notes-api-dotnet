using System.ComponentModel.DataAnnotations;

namespace Notes_API.Data.Dtos.UserDtos
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }
    }
}
