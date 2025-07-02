using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.RecipeIngredientDTOs
{
    public class CreateRecipeIngredientDto
    {
        [Required(ErrorMessage = "Název ingredience je povinný údaj")]
        public string? IngredientName { get; set; }

        [Range(0.01, double.MaxValue)]
        public double? Quantity { get; set; }

        [Required(ErrorMessage = "Vyberte jednotku")]
        public string? Unit { get; set; }
    }
}
