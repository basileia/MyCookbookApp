using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        Task<Recipe?> GetByIdWithDetailsAsync(int id);
        Task<Recipe?> GetByNameAsync(string name);
        Task<List<Recipe?>> GetFilteredAsync(FilterCriteriaDto filter, string userId);
    }
}
