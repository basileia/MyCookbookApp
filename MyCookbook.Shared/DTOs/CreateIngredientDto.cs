using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs
{
    public class CreateIngredientDto
    {
        [Required]
        public string Name { get; set; }
    }
}
