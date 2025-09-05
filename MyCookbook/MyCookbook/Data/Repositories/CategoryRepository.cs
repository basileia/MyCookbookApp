using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetByIdsAsync(IEnumerable<int> categoryIds)
        {
            return await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();
        }
    }
}
