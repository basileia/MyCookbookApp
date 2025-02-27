using AutoMapper;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.RecipeDTOs;

namespace MyCookbook.Extensions
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDetailDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));

            CreateMap<Recipe, RecipeListDto>();            
        }
    }
}
