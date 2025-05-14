using MyCookbook.Shared.DTOs.IngredientDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IIngredientService
    {
        Task<List<IngredientDto>> GetAllAsync();
        Task<IngredientDto> AddAsync(CreateIngredientDto createIngredientDto);
    }
}
