using LanguageExt;
using MyCookbook.Results;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeListDto>> GetAllRecipesAsync();
        Task<RecipeDetailDto?> GetRecipeByIdAsync(int id);
        Task<Result<Unit, Error>> DeleteRecipeAsync(int id, string userId);
        Task<Result<RecipeDetailDto, Error>> AddNewRecipeAsync(CreateRecipeDto createRecipeDto, string userId);
        Task<Result<Unit, Error>> UpdateRecipeAsync(int id, UpdateRecipeDto updateRecipeDto, string userId);
        Task<Result<UpdateRecipeDto, Error>> GetRecipeForUpdateAsync(int id);
    }
}
