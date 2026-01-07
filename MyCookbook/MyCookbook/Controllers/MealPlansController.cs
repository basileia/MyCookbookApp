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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealPlanById(int id)
        {
            var userId = GetUserId();
            var result = await _mealPlanService.GetMealPlanByIdAsync(userId, id);
            return GetResponse(result);
        }
    }
}
