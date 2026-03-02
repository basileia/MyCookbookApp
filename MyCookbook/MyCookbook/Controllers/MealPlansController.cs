using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Shared.DTOs.MealPlanDTOs;

namespace MyCookbook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlansController : BaseController
    {
        private readonly IMealPlanService _mealPlanService;
        public MealPlansController(IMealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMealPlan([FromBody] NewMealPlanDto newMealPlanDto)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Uživatel není přihlášen.");

            var result = await _mealPlanService.CreateMealPlanAsync(userId, newMealPlanDto);

            return GetResponse(
                result,
                actionName: nameof(GetMealPlanById),
                routeValues: new { id = result.Value?.Id }
            );
        }

        [Authorize]
        [HttpPut("{id}/rename")]
        public async Task<IActionResult> Rename(int id, RenameMealPlanDto renameMealPlanDto)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Uživatel není přihlášen.");

            var result = await _mealPlanService.RenameMealPlanAsync(id, renameMealPlanDto.Name, userId);
            return GetResponse(result);                
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealPlanById(int id)
        {
            var userId = GetUserId();
            var result = await _mealPlanService.GetMealPlanByIdAsync(userId, id);
            return GetResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMealPlans()
        {
            var userId = GetUserId();
            var result = await _mealPlanService.GetAllMealPlansAsync(userId);
            return GetResponse(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealPlan(int id)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Uživatel není přihlášen.");

            var result = await _mealPlanService.DeleteMealPlanAsync(userId, id);

            return GetResponse(result);
        }

        [Authorize]
        [HttpPost("{id}/duplicate")]
        public async Task<IActionResult> Duplicate(int id)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Uživatel není přihlášen.");

            var result = await _mealPlanService.DuplicateMealPlanAsync(userId, id);

            return GetResponse(result);
        }
    }
}
