namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IRecipeIngredientRepository : IBaseRepository<RecipeIngredient>
    {

        Task<RecipeIngredient?> FindByIdsAsync(int recipeId, int ingredientId);       
    }
}
