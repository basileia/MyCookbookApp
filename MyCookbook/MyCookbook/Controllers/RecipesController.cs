using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Shared.DTOs.RecipeDTOs;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;
using System.Security.Claims;

namespace MyCookbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipesController(IRecipeService recipeService, IRecipeIngredientService recipeIngredientService)
        {
            _recipeService = recipeService;
            _recipeIngredientService = recipeIngredientService;
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

        [HttpGet("update/{id}")]
        public async Task<ActionResult<Response<UpdateRecipeDto>>> GetRecipeForUpdate(int id)
        {
            var result = await _recipeService.GetRecipeForUpdateAsync(id);

            return GetResponse(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Uživatel není přihlášen.");

            var result = await _recipeService.DeleteRecipeAsync(id, userId);

            return GetResponse(result);
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRecipe(int id, [FromBody] UpdateRecipeDto updateRecipeDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Uživatel není přihlášen.");
            }

            var result = await _recipeService.UpdateRecipeAsync(id, updateRecipeDto, userId);

            return GetResponse(result);
        }

        [HttpPost("{recipeId}/ingredients")]
        public async Task<IActionResult> AddIngredientToRecipe(int recipeId, [FromBody] CreateRecipeIngredientDto dto)
        {
            var result = await _recipeIngredientService.AddIngredientToRecipeAsync(recipeId, dto);

            return GetResponse(result);                               
        }
    }
}
