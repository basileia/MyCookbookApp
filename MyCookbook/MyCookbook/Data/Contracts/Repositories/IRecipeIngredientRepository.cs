namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IRecipeIngredientRepository : IBaseRepository<RecipeIngredient>
    {
        Task<IEnumerable<RecipeIngredient>> GetByRecipeIdAsync(int recipeId);
        Task<RecipeIngredient?> FindByIdsAsync(int recipeId, int ingredientId);

    }
}
