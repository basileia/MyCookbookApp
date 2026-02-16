using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IMealPlanRepository :IBaseRepository<MealPlan>
    {
        Task<MealPlan?> GetWithDaysAndRecipesAsync(int id, string userId);
        Task AddWithDaysAndRecipesAsync(MealPlan mealPlan);
        Task<List<MealPlan>> GetAllByUserIdAsync(string userId);
        Task<MealPlan?> GetByIdAsync(int id, string userId);
    }
}
