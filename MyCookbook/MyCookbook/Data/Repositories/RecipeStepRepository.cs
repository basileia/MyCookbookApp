using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class RecipeStepRepository : BaseRepository<RecipeStep>, IRecipeStepRepository
    {
        public RecipeStepRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeAsync(IEnumerable<RecipeStep> steps)
        {
            await _context.RecipeSteps.AddRangeAsync(steps);
            await _context.SaveChangesAsync();
        }
    }
}
