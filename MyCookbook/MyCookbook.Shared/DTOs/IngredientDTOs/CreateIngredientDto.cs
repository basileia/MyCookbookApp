using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.IngredientDTOs
{
    public class CreateIngredientDto
    {
        [Required(ErrorMessage = "Název ingredience je povinný.")]
        public string Name { get; set; } = string.Empty;
    }
}
