using MyCookbook.Results;
using MyCookbook.Shared.DTOs.UserRecipeStatusDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IUserRecipeStatusService
    {
        Task<Result<UserRecipeStatusDto, Error>> GetStatusAsync(string userId, int recipeId);
        //Task<UserRecipeStatusDto> UpdateStatusAsync(string userId, UpdateUserRecipeStatusDto updateDto);
    }
}
