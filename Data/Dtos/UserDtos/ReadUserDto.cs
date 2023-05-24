using System.ComponentModel.DataAnnotations;

namespace Notes_API.Data.Dtos.UserDtos
{
    public class ReadUserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Password { get; set; }

        public string? Photo { get; set; }
    }
}
