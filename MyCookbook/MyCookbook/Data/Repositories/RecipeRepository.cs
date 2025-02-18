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
            return await _context.Recipes
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
