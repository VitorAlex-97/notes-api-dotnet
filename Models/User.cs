using System.ComponentModel.DataAnnotations;

namespace Notes_API.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Photo { get; set; }
    }
}
