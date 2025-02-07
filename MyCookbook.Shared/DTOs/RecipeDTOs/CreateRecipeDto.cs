using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;
using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class CreateRecipeDto
    {
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int NumberOfServings { get; set; }

        [Required]
        public string Preparation { get; set; }

        public List<int> CategoryIds { get; set; }
        public List<CreateRecipeIngredientDto> Ingredients { get; set; }
    }
}
