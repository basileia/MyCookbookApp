using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class UserRecipeStatusRepository : BaseRepository<UserRecipeStatus>, IUserRecipeStatusRepository
    {
        public UserRecipeStatusRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<UserRecipeStatus?> GetStatusAsync(string userId, int recipeId)
        {
            return await _context.UserRecipeStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == userId && s.RecipeId == recipeId);
        }
    }
}
