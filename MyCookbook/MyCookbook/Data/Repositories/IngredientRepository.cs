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

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients
                .OrderBy(i => i.Name)
                .ToListAsync();
        }        
    }
}
