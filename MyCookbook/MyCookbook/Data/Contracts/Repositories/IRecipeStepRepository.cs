using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IRecipeStepRepository : IBaseRepository<RecipeStep>
    {
        Task AddRangeAsync(IEnumerable<RecipeStep> steps);
    }
}
