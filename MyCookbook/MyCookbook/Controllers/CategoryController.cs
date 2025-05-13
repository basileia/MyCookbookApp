using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Shared.DTOs.CategoryDTOs;

namespace MyCookbook.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()  //solve errors (Error, Result)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
    }
}
