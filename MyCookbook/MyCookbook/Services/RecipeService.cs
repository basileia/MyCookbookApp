﻿using AutoMapper;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeListDto>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllWithCategoriesAsync();
            return _mapper.Map<List<RecipeListDto>>(recipes);
        }

        public async Task<RecipeDetailDto?> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdWithDetailsAsync(id);
            return recipe == null ? null : _mapper.Map<RecipeDetailDto>(recipe);
        }
    }
}
