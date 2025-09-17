using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IUserRecipeStatusRepository
    {
        Task<UserRecipeStatus?> GetStatusAsync(string userId, int recipeId);
        //Task AddOrUpdateStatusAsync(UserRecipeStatus status);
    }
}
