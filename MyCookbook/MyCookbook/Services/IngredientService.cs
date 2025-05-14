using AutoMapper;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Results;
using MyCookbook.Results.Errors;
using MyCookbook.Shared.DTOs.IngredientDTOs;

namespace MyCookbook.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;               
        }

        public async Task<List<IngredientDto>> GetAllAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return _mapper.Map<List<IngredientDto>>(ingredients);
        }

        public async Task<Result<IngredientDto, Error>> AddAsync(CreateIngredientDto dto)
        {
            var existing = await _ingredientRepository.GetByNameAsync(dto.Name);

            if (existing is not null)
            {
                return IngredientError.DuplicateName;
            }

            var ingredient = _mapper.Map<Ingredient>(dto);

            await _ingredientRepository.AddAsync(ingredient);
            return _mapper.Map<IngredientDto>(ingredient);
        }
    }
}
