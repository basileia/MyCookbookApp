using MyCookbook.Results;
using MyCookbook.Shared.DTOs.IngredientDTOs;

namespace MyCookbook.Data.Contracts.Services
{
    public interface IIngredientService
    {
        Task<List<IngredientDto>> GetAllAsync();
        Task<Result<IngredientDto, Error>> AddAsync(CreateIngredientDto dto);
    }
}
