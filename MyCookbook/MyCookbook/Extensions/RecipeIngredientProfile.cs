using AutoMapper;
using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

namespace MyCookbook.Extensions
{
    public class RecipeIngredientProfile : Profile
    {
        public RecipeIngredientProfile()
        {
            CreateMap<RecipeIngredient, RecipeIngredientDto>()
            .ForMember(dest => dest.IngredientName, opt => opt.MapFrom(src => src.Ingredient.Name));

            CreateMap<RecipeIngredientDto, RecipeIngredient>();

            CreateMap<CreateRecipeIngredientDto, RecipeIngredient>().ReverseMap();
        }
    }
}
