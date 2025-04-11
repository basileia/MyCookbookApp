using AutoMapper;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeListDto>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllWithCategoriesAsync();
            return _mapper.Map<List<RecipeListDto>>(recipes);
        }

        public async Task<RecipeDetailDto?> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdWithDetailsAsync(id);
            return recipe == null ? null : _mapper.Map<RecipeDetailDto>(recipe);
        }

        public async Task<bool> DeleteRecipeAsync(int id, string userId)
        {
            var recipe = await _recipeRepository.GetByIdWithDetailsAsync(id);

            if (recipe == null)
            {
                return false;
            }

            if (recipe.UserId != userId)
            {
                throw new UnauthorizedAccessException("Nemáte oprávnění smazat tento recept.");
            }

            await _recipeRepository.DeleteAsync(recipe);
            return true;
        }

        public async Task AddNewRecipeAsync(Recipe recipe, string userId)
        {
            // validation, mapping
            await _recipeRepository.AddAsync(recipe);
        }
    }
}
