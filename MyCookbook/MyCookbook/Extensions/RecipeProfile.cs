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

            CreateMap<CreateRecipeDto, Recipe>()
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())     
            .ForMember(dest => dest.DateAdded, opt => opt.Ignore())  
            .ForMember(dest => dest.User, opt => opt.Ignore());
            
            CreateMap<Recipe, CreateRecipeDto>()
            .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src => src.Categories.Select(c => c.Id)))
            .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.Steps))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));
        }
    }
}
