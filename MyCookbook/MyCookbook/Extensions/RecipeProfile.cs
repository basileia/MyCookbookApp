//using AutoMapper;
//using MyCookbook.Data.Models;
//using MyCookbook.Shared.DTOs;
//using MyCookbook.Shared.DTOs.RecipeDTOs;
//using MyCookbook.Shared.DTOs.RecipeIngredientDTOs;

//namespace MyCookbook.Extensions
//{
//    public class RecipeProfile : Profile
//    {
//        public RecipeProfile()
//        {
//            CreateMap<Recipe, RecipeDto>()
//            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName)) 
//            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories)) 
//            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));

//            CreateMap<RecipeIngredient, RecipeIngredientDto>(); 
//            CreateMap<Category, CategoryDto>(); 
//        }
//    }
//}
