using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetByIdsAsync(IEnumerable<int> categoryIds);
    }
}
