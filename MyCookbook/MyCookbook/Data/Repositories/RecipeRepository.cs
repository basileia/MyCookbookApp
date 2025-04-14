using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Recipe>> GetAllWithCategoriesAsync()
        {
            return await _context.Recipes
                .Include(r => r.Categories)
                .ToListAsync();
        }

        public async Task<Recipe?> GetByIdWithDetailsAsync(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.Steps)       
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (recipe != null)
            {
                recipe.Steps = recipe.Steps.OrderBy(s => s.StepNumber).ToList();
            }

            return recipe;
        }

        public async Task<Recipe?> GetByNameAsync(string name)
        {
            return await _context.Recipes
                .Include(r => r.Categories)
                .FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }
    }
}
