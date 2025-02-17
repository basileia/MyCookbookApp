using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.RecipeIngredientDTOs
{
    public class CreateRecipeIngredientDto
    {
        public int IngredientId { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Quantity { get; set; }

        [Required]
        public string Unit { get; set; }
    }
}
