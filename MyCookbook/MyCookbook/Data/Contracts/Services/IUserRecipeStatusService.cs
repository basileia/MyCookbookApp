using MyCookbook.Results;
using MyCookbook.Shared.DTOs.UserRecipeStatusDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IUserRecipeStatusService
    {
        Task<Result<UserRecipeStatusDto, Error>> GetStatusAsync(string userId, int recipeId);
        Task<Result<UserRecipeStatusDto, Error>> UpdateStatusAsync(string userId, UpdateUserRecipeStatusDto dto);
    }
}
