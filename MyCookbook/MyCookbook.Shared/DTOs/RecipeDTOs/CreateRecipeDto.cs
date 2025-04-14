using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;
using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class CreateRecipeDto
    {
        [Required(ErrorMessage = "Název je povinný údaj")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Název musí mít 3-100 znaků")]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Počet porcí musí být alespoň 1")]
        public int NumberOfServings { get; set; }

        [Required]
        public List<RecipeStepDto> Steps { get; set; } = new();

        public List<int> CategoryIds { get; set; } = new();
        public List<CreateRecipeIngredientDto> Ingredients { get; set; } = new();
    }
}
