namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IRecipeIngredientRepository : IBaseRepository<RecipeIngredient>
    {
        Task<IEnumerable<RecipeIngredient>> GetByRecipeIdAsync(int recipeId);
        Task<RecipeIngredient?> GetByIdsAsync(int recipeId, int ingredientId);
    }
}
