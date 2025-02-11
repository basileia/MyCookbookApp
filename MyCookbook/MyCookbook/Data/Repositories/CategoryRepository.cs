using MyCookbook.Data.Contracts;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
