using System.ComponentModel.DataAnnotations;

namespace Notes_API.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }

        [Required] 
        public string Label { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
