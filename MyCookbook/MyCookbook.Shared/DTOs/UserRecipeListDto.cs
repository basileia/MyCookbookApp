using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Shared.DTOs
{
    public class UserRecipeListDto
    {
        public string UserId { get; set; }
        public List<RecipeDto> Recipes { get; set; }
    }
}
