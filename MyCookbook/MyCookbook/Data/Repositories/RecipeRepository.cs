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
                .Where(r => r.Id == id)
                .Select(r => new Recipe
                {
                    Id = r.Id,
                    Name = r.Name,
                    NumberOfServings = r.NumberOfServings,
                    UserId = r.UserId,
                    Categories = r.Categories,
                    Ingredients = r.Ingredients,
                    Steps = r.Steps.OrderBy(s => s.StepNumber).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
