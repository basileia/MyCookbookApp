using AutoMapper;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Extensions
{
    public class RecipeStepProfile : Profile
    {
        public RecipeStepProfile()
        {
            CreateMap<RecipeStep, RecipeStepDto>().ReverseMap();
        }
    }
}
