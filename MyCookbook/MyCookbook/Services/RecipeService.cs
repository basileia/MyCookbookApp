using AutoMapper;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.RecipeDTOs;
using MyCookbook.Results;
using LanguageExt.Common;

namespace MyCookbook.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public RecipeService(IRecipeRepository recipeRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
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

        public async Task<Result<RecipeDetailDto, Error>> AddNewRecipeAsync(CreateRecipeDto createRecipeDto, string userId)
        {
            var recipe = _mapper.Map<Recipe>(createRecipeDto);

            var existing = await _recipeRepository.GetByNameAsync(recipe.Name);
            if (existing is not null)
            {
                return Result.Fail("Recept s tímto názvem už existuje.");
            }

            recipe.UserId = userId;
            recipe.DateAdded = DateTime.Now;

            if (createRecipeDto.CategoryIds.Any())
            {
                var categories = await _categoryRepository
                    .GetAllAsync();

                recipe.Categories = categories
                    .Where(c => createRecipeDto.CategoryIds.Contains(c.Id))
                    .ToList();
            }

            return await _recipeRepository.AddAsync(recipe);
        }
    }
}
