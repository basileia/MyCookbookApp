using MyCookbook.Shared.DTOs.CategoryDTOs;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfServings { get; set; }
        public List<RecipeStepDto> Steps { get; set; } = new();
        public List<int> CategoryIds { get; set; } = new();
        public List<RecipeIngredientDto> Ingredients { get; set; } = new();
    }
}
