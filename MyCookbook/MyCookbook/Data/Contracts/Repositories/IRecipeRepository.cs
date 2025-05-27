using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        Task<List<Recipe>> GetAllWithCategoriesAsync();
        Task<Recipe?> GetByIdWithDetailsAsync(int id);
        Task<Recipe?> GetByNameAsync(string name);
    }
}
