using AutoMapper;
using LanguageExt;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Results;
using MyCookbook.Results.Errors;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;
using Error = MyCookbook.Results.Error;

namespace MyCookbook.Services
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeIngredientService(
        IRecipeIngredientRepository recipeIngredientRepository,
        IIngredientRepository ingredientRepository,
        IRecipeRepository recipeRepository,
        IMapper mapper)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<Result<RecipeIngredientDto, Error>> AddIngredientToRecipeAsync(int recipeId, CreateRecipeIngredientDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);
            if (recipe == null)
                return RecipeError.RecipeNotFound;

            var normalizedName = Ingredient.Normalize(dto.IngredientName);
            var ingredient = await _ingredientRepository
                .FindByNormalizedNameAsync(normalizedName);

            if (ingredient == null)
            {
                ingredient = new Ingredient
                {
                    Name = dto.IngredientName.Trim(),
                    NormalizedName = normalizedName
                };
                await _ingredientRepository.AddAsync(ingredient);
            }
            else
            {
                dto.IngredientName = ingredient.Name;
            }

            var existing = await _recipeIngredientRepository
                .FindByIdsAsync(recipeId, ingredient.Id);
            if (existing != null)
                return RecipeError.IngredientAlreadyInRecipe;
        
            var recipeIngredient = new RecipeIngredient
            {
                RecipeId = recipeId,
                IngredientId = ingredient.Id,
                Quantity = (double)dto.Quantity,
                Unit = dto.Unit
            };

            await _recipeIngredientRepository.AddAsync(recipeIngredient);

            var recipeIngredientDto = new RecipeIngredientDto
            {
                IngredientId = ingredient.Id,
                IngredientName = ingredient.Name,
                Quantity = recipeIngredient.Quantity,
                Unit = recipeIngredient.Unit
            };

            return recipeIngredientDto;
        }

        public async Task<Result<Unit, Error>> ReplaceAllIngredientsAsync(Recipe existingRecipe, IEnumerable<CreateRecipeIngredientDto> ingredientDtos)
        {
            existingRecipe.Ingredients.Clear();
            await _recipeRepository.SaveAsync(existingRecipe);
            
            foreach (var dto in ingredientDtos)
            {
                var addResult = await AddIngredientToRecipeAsync(existingRecipe.Id, dto);
                if (!addResult.IsSuccess)
                {
                    return addResult.Error;
                }
            }

            return Unit.Default;
        }
    }
}
