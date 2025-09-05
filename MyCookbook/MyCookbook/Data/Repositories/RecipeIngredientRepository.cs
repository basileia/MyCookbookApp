using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;

namespace MyCookbook.Data.Repositories
{
    public class RecipeIngredientRepository : BaseRepository<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(ApplicationDbContext context) : base(context)
        {
        }        

        public async Task<RecipeIngredient?> FindByIdsAsync(int recipeId, int ingredientId)
        {
            return await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);
        }
    }
}
