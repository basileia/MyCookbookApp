using LanguageExt;
using MyCookbook.Results;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IRecipeIngredientService
    {
        Task<Result<RecipeIngredientDto, Error>> AddIngredientToRecipeAsync(int recipeId, CreateRecipeIngredientDto dto);
    }
}
