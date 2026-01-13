using MyCookbook.Results;
using MyCookbook.Shared.DTOs.MealPlanDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IMealPlanService
    {
        Task<Result<MealPlanDetailDto, Error>> CreateMealPlanAsync(string userId, NewMealPlanDto newMealPlanDto);
        Task<Result<MealPlanDetailDto, Error>> GetMealPlanByIdAsync(string userId, int mealPlanId);
        Task<Result<List<MealPlanListDto>, Error>> GetAllMealPlansAsync(string userId);
    }
}
