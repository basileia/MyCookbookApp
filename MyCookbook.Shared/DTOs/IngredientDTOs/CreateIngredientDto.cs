using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.IngredientDTOs
{
    public class CreateIngredientDto
    {
        [Required]
        public string Name { get; set; }
    }
}
