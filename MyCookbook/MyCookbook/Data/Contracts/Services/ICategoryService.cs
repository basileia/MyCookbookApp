using MyCookbook.Shared.DTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
    }
}
