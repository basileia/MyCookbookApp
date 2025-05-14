using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient?> GetByNameAsync(string name);
        //Task<Ingredient?> GetByIdAsync(int id);        
    }
}
