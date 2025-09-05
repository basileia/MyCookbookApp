using LanguageExt;
using MyCookbook.Data.Models;
using MyCookbook.Results;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IRecipeIngredientService
    {
        Task<Result<RecipeIngredientDto, Error>> AddIngredientToRecipeAsync(int recipeId, CreateRecipeIngredientDto dto);
        Task<Result<Unit, Error>> ReplaceAllIngredientsAsync(Recipe recipe, IEnumerable<CreateRecipeIngredientDto> newIngredients);
    }
}
