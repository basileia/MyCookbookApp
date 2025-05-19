using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients
                .OrderBy(i => i.Name)
                .ToListAsync();
        }
        
        public async Task<Ingredient?> GetByNameAsync(string name)
        {
            return await _context.Ingredients
                .FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        public async Task<Ingredient?> FindByNormalizedNameAsync(string normalizedName)
        {
            return await _context.Ingredients
                .FirstOrDefaultAsync(i => i.NormalizedName == normalizedName);
        }
    }
}
