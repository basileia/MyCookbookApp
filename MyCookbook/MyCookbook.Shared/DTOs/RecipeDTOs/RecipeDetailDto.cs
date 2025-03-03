using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class RecipeDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfServings { get; set; }
        public List<RecipeStepDto> Steps { get; set; } = new();
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
        public List<RecipeIngredientDto> Ingredients { get; set; } = new();
    }
}
