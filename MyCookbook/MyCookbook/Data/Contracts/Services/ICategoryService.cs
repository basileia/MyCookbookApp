using MyCookbook.Shared.DTOs.CategoryDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
    }
}
