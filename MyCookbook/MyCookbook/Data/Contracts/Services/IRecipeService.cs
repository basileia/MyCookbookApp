using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeListDto>> GetAllRecipesAsync();
        Task<RecipeDetailDto?> GetRecipeByIdAsync(int id);
        Task<bool> DeleteRecipeAsync(int id, string userId);
        Task AddNewRecipeAsync(Recipe recipe, string userId);
    }
}
