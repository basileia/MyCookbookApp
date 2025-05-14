using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;

namespace MyCookbook.Data.Repositories
{
    public class RecipeIngredientRepository : BaseRepository<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RecipeIngredient>> GetByRecipeIdAsync(int recipeId)
        {
            return await _context.RecipeIngredients
                .Include(ri => ri.Ingredient)
                .Where(ri => ri.RecipeId == recipeId)
                .ToListAsync();
        }

        public async Task<RecipeIngredient?> GetByIdsAsync(int recipeId, int ingredientId)
        {
            return await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);
        }
    }
}
