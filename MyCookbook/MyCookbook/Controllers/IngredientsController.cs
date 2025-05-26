using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.IngredientDTOs;

namespace MyCookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : BaseController
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientDto>>> GetAll()
        {
            return await _ingredientService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IngredientDto>> AddIngredient(CreateIngredientDto dto)
        {
            var result = await _ingredientService.AddAsync(dto);
            return GetResponse(result, nameof(GetAll), new { id = result.Value?.Id });
        }

        //[HttpGet("search")]
        //public async Task<ActionResult<List<string>>> SearchIngredients([FromQuery] string query)
        //{
        //    if (string.IsNullOrWhiteSpace(query))
        //        return BadRequest("Zadejte hledaný výraz.");

        //    var normalizedQuery = Ingredient.Normalize(query);
        //    var suggestions = await _ingredientRepository
        //        .SearchByNormalizedNamePrefixAsync(normalizedQuery);

        //    return Ok(suggestions.Select(i => i.Name).ToList());
        //}
    }
}
