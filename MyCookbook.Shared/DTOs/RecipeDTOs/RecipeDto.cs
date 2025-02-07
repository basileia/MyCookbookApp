using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfServings { get; set; }
        public string Preparation { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
    }
}
