using AutoMapper;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Results;
using MyCookbook.Results.Errors;
using MyCookbook.Shared.DTOs;
using MyCookbook.Shared.DTOs.MealPlanDTOs;

namespace MyCookbook.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMealPlanRepository _mealPlanRepository;

        public MealPlanService(IMapper mapper, IMealPlanRepository mealPlanRepository, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _mealPlanRepository = mealPlanRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<Result<MealPlanDetailDto, Error>> CreateMealPlanAsync(string userId, NewMealPlanDto newMealPlanDto)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return UserError.Unauthorized;
            }

            var filter = new FilterCriteriaDto
            {
                Favorites = newMealPlanDto.FilterFavorites,
                Tried = newMealPlanDto.FilterTried,
                Mine = newMealPlanDto.FilterMine
            };
            var filteredRecipes = await _recipeRepository.GetFilteredAsync(filter, userId);                      

            var mealPlan = new MealPlan { 
                CreatedAt = DateTime.UtcNow,
                Days = newMealPlanDto.Days,
                Name = newMealPlanDto.Name,
                StartDayOfWeek = newMealPlanDto.StartDayOfWeek,
                DaysPlan = new List<MealPlanDay>(),
                UserId = userId
            };

            for (int i = 0; i < newMealPlanDto.Days; i++)
            {
                var dayOfWeek = (DayOfWeek)(((int)newMealPlanDto.StartDayOfWeek + i) % 7);

                var day = new MealPlanDay
                {
                    DayNumber = i + 1,
                    DayOfWeek = dayOfWeek,
                    Recipes = new List<MealPlanRecipe>()
                };

                mealPlan.DaysPlan.Add(day);
            }

            var categories = new[] { 1, 2, 3, 4 };
            var usedRecipeIds = new HashSet<int>();

            foreach (var day in mealPlan.DaysPlan)
            {
                foreach (var categoryId in categories)
                {
                    var candidates = filteredRecipes
                    .Where(r => !usedRecipeIds.Contains(r.Id) && r.Categories.Any(c => c.Id == categoryId))
                    .ToList();

                    if (candidates.Any())
                    {
                        var recipe = PickRandom(candidates);

                        day.Recipes.Add(new MealPlanRecipe
                        {
                            RecipeId = recipe.Id
                        });

                        usedRecipeIds.Add(recipe.Id);
                    }                    
                }
            }

             await _mealPlanRepository.AddWithDaysAndRecipesAsync(mealPlan);

            var mealPlanDetailDto = _mapper.Map<MealPlanDetailDto>(mealPlan);
            return mealPlanDetailDto;
        }

        public async Task<Result<MealPlanDetailDto, Error>> GetMealPlanByIdAsync(string userId, int mealPlanId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return UserError.Unauthorized;
            }
            var mealPlan = await _mealPlanRepository.GetWithDaysAndRecipesAsync(mealPlanId, userId);
            if (mealPlan == null)
            {
                return MealPlanError.MealPlanNotFound;
            }
            var mealPlanDetailDto = _mapper.Map<MealPlanDetailDto>(mealPlan);
            return mealPlanDetailDto;
        }

        private Recipe PickRandom(List<Recipe> recipes)
        {
            var index = Random.Shared.Next(recipes.Count);
            return recipes[index];
        }
    } 

        /* Editace poznámek, nahrazení receptů
            Zajištění, že jídelníčky patří jen danému uživateli*/
}
