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
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper, IRecipeIngredientService recipeIngredientService)
        {
            _ingredientRepository = ingredientRepository;
            _recipeIngredientService = recipeIngredientService;
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
            ingredient.NormalizedName = Ingredient.Normalize(ingredient.Name);

            await _ingredientRepository.AddAsync(ingredient);
            return _mapper.Map<IngredientDto>(ingredient);
        }

        public async Task<Result<List<string>, Error>> SearchNamesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return IngredientError.InvalidQuery;
            }

            var normalized = Ingredient.Normalize(query);
            var ingredients = await _ingredientRepository.SearchByNormalizedNamePrefixAsync(normalized);

            var names = ingredients
                .Select(i => i.Name)
                .ToList();

            return names;
        }
    }
}
