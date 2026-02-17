using AutoMapper;
using LanguageExt;
using MyCookbook.Client.Pages;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Results;
using MyCookbook.Results.Errors;
using MyCookbook.Services.Helpers;
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

            var existing = await _mealPlanRepository.GetByNameAsync(newMealPlanDto.Name.Trim(), userId);
            if (existing != null)
                return MealPlanError.DuplicateName;

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
            var usedRecipeIds = new System.Collections.Generic.HashSet<int>();

            foreach (var day in mealPlan.DaysPlan)
            {
                foreach (var categoryId in categories)
                {
                    var candidates = filteredRecipes
                    .Where(r => !usedRecipeIds.Contains(r.Id) && r.Categories.Any(c => c.Id == categoryId))
                    .ToList();

                    int? recipeId = null;
                    if (candidates.Any())
                    {
                        var recipe = PickRandom(candidates);
                        recipeId = recipe.Id;
                        usedRecipeIds.Add(recipe.Id);
                    }

                    day.Recipes.Add(new MealPlanRecipe
                    {
                        CategoryId = categoryId,
                        RecipeId = recipeId
                    });
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

        public async Task<Result<List<MealPlanListDto>, Error>> GetAllMealPlansAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return UserError.Unauthorized;
            }

            var mealPlans = await _mealPlanRepository.GetAllByUserIdAsync(userId);
            var mealPlanListDtos = _mapper.Map<List<MealPlanListDto>>(mealPlans);
            return mealPlanListDtos;
        }

        public async Task<Result<Unit, Error>> DeleteMealPlanAsync(string userId, int mealPlanId)
        {
            var mealPlan = await _mealPlanRepository
                .GetByIdAsync(mealPlanId, userId);

            if (mealPlan == null)
            {
                return MealPlanError.MealPlanNotFound;
            }

            await _mealPlanRepository.DeleteAsync(mealPlan);

            return Unit.Default;
        }

        public async Task<Result<MealPlanDetailDto, Error>> DuplicateMealPlanAsync(string userId, int mealPlanId)
        {
            if (string.IsNullOrEmpty(userId))
                return UserError.Unauthorized;

            var original = await _mealPlanRepository.GetWithDaysAndRecipesAsync(mealPlanId, userId);

            if (original == null)
                return MealPlanError.MealPlanNotFound;

            var allUserPlans = await _mealPlanRepository.GetAllByUserIdAsync(userId);
            var existingNames = allUserPlans.Select(p => p.Name).ToList();

            var newName = MealPlanNamingHelper.GetNextCopyName(original.Name, existingNames);

            var copy = new MealPlan
            {
                Name = newName,
                StartDayOfWeek = original.StartDayOfWeek,
                Days = original.Days,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                DaysPlan = original.DaysPlan.Select(d => new MealPlanDay
                {
                    DayNumber = d.DayNumber,
                    DayOfWeek = d.DayOfWeek,
                    Recipes = d.Recipes.Select(r => new MealPlanRecipe
                    {
                        CategoryId = r.CategoryId,
                        RecipeId = r.RecipeId
                    }).ToList()
                }).ToList()
            };

            await _mealPlanRepository.AddWithDaysAndRecipesAsync(copy);

            var copyDto = _mapper.Map<MealPlanDetailDto>(copy);

            return copyDto;
        }
    } 

        
}
