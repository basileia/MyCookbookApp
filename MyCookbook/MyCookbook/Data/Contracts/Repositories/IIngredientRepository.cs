using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task<Ingredient?> GetByNameAsync(string name);
        Task<Ingredient?> FindByNormalizedNameAsync(string normalizedName);
        //Task<Ingredient?> GetByIdAsync(int id);        
    }
}
