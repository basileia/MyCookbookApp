using AutoMapper;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;
using MyCookbook.Results;
using MyCookbook.Results.Errors;
using MyCookbook.Shared.DTOs.UserRecipeStatusDTOs;

namespace MyCookbook.Services
{
    public class UserRecipeStatusService : IUserRecipeStatusService
    {
        private readonly IUserRecipeStatusRepository _userRecipeStatusRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public UserRecipeStatusService(IUserRecipeStatusRepository userRecipeStatusRepository, IRecipeRepository recipeRepository, IMapper mapper)
        {
            _userRecipeStatusRepository = userRecipeStatusRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserRecipeStatusDto, Error>> GetStatusAsync(string userId, int recipeId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return UserError.Unauthenticated;
            }

            var recipe = await _recipeRepository.GetByIdAsync(recipeId);
            if (recipe == null)
            {
                return RecipeError.RecipeNotFound;
            }

            var status = await _userRecipeStatusRepository.GetStatusAsync(userId, recipeId);

            if (status == null)
            {
                return new UserRecipeStatusDto
                {
                    RecipeId = recipeId,
                    IsFavourite = false,
                    IsTried = false
                };
            }

            return _mapper.Map<UserRecipeStatusDto>(status);
        }

        public async Task<Result<UserRecipeStatusDto, Error>> UpdateStatusAsync(string userId, UpdateUserRecipeStatusDto updateRecipeStatusDto)
        {
            var status = await _userRecipeStatusRepository.GetStatusAsync(userId, updateRecipeStatusDto.RecipeId);

            if (status == null)
            {
                status = new UserRecipeStatus
                {
                    UserId = userId,
                    RecipeId = updateRecipeStatusDto.RecipeId,
                    IsFavourite = updateRecipeStatusDto.IsFavourite ?? false,
                    IsTried = updateRecipeStatusDto.IsTried ?? false
                };

                await _userRecipeStatusRepository.AddAsync(status);
            }
            else
            {
                if (updateRecipeStatusDto.IsFavourite.HasValue)
                    status.IsFavourite = updateRecipeStatusDto.IsFavourite.Value;

                if (updateRecipeStatusDto.IsTried.HasValue)
                    status.IsTried = updateRecipeStatusDto.IsTried.Value;

                await _userRecipeStatusRepository.UpdateAsync(status);
            }

            return _mapper.Map<UserRecipeStatusDto>(status);
        }
    }
}
