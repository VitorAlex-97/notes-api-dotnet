using System.ComponentModel.DataAnnotations;

namespace Notes_API.Data.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {

        [Required]
        public string Label { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
