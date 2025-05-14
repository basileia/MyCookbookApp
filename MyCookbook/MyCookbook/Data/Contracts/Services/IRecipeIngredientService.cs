using LanguageExt;
using MyCookbook.Results;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IRecipeIngredientService
    {
        Task<Result<Unit, string>> AddIngredientToRecipeAsync(int recipeId, CreateRecipeIngredientDto dto);
        Task<Result<IEnumerable<RecipeIngredientDto>, string>> GetIngredientsForRecipeAsync(int recipeId);
    }
}
