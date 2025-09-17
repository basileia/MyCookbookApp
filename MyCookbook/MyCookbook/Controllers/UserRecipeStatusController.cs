using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Shared.DTOs.UserRecipeStatusDTOs;

namespace MyCookbook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRecipeStatusController : BaseController
    {
        private readonly IUserRecipeStatusService _userRecipeStatusService;

        public UserRecipeStatusController(IUserRecipeStatusService userRecipeStatusService)
        {
            _userRecipeStatusService = userRecipeStatusService;
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetStatus(int recipeId)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Uživatel není přihlášen.");
            }
            var result = await _userRecipeStatusService.GetStatusAsync(userId, recipeId);
            return GetResponse(result);
        }

        //[HttpPost("update-status")]
        //public async Task<IActionResult> UpdateStatus(UpdateUserRecipeStatusDto updateDto)
        //{
        //    var userId = GetUserId();

        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return Unauthorized("Uživatel není přihlášen.");
        //    }
        //    var result = await _userRecipeStatusService.UpdateStatusAsync(userId, updateDto);
        //    return GetResponse(result);
        //}

    }
}
