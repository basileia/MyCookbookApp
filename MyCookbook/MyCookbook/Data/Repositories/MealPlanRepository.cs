using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class MealPlanRepository : BaseRepository<MealPlan>, IMealPlanRepository
    {
        public MealPlanRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddWithDaysAndRecipesAsync(MealPlan mealPlan)
        {
            await _context.MealPlans.AddAsync(mealPlan);
            await _context.SaveChangesAsync();
        }

        public async Task<MealPlan?> GetWithDaysAndRecipesAsync(int id, string userId)
        {
            return await _context.MealPlans
                .Where(mp => mp.Id == id && mp.UserId == userId)
                .Include(mp => mp.DaysPlan)
                    .ThenInclude(d => d.Recipes)
                .FirstOrDefaultAsync();
        }
    }
}
