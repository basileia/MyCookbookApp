using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Results;
using MyCookbook.Shared.DTOs.RecipeDTOs;
using System.Security.Claims;

namespace MyCookbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : BaseController
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeListDto>>> GetRecipes()
        {
            return await _recipeService.GetAllRecipesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDetailDto>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null) return NotFound("Recept nebyl nalezen");
            return Ok(recipe);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Uživatel není přihlášen.");
            }

            try
            {
                var success = await _recipeService.DeleteRecipeAsync(id, userId);
                if (!success)
                {
                    return NotFound("Recept nebyl nalezen.");
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddRecipe([FromBody] CreateRecipeDto createRecipeDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Uživatel není přihlášen.");
            }

            var result = await _recipeService.AddNewRecipeAsync(createRecipeDto, userId);

            return GetResponse(result, nameof(GetRecipe), new { id = result.Value?.Id });
        }
    }
}
