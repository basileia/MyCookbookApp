using MyCookbook.Data.Models;

namespace MyCookbook.Data.Contracts.Repositories
{
    public interface IUserRecipeStatusRepository : IBaseRepository<UserRecipeStatus>
    {
        Task<UserRecipeStatus?> GetStatusAsync(string userId, int recipeId);
        //Task AddOrUpdateStatusAsync(UserRecipeStatus status);
    }
}
