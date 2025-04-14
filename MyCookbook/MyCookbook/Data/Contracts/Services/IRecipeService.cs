using LanguageExt.Common;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeListDto>> GetAllRecipesAsync();
        Task<RecipeDetailDto?> GetRecipeByIdAsync(int id);
        Task<bool> DeleteRecipeAsync(int id, string userId);
        Task<Result<RecipeDetailDto>> AddNewRecipeAsync(CreateRecipeDto createRecipeDto, string userId);
    }
}
