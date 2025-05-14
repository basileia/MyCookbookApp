using AutoMapper;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.CategoryDTOs;
using MyCookbook.Shared.DTOs.IngredientDTOs;

namespace MyCookbook.Extensions
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Ingredient, CreateIngredientDto>().ReverseMap();
        }
    }
}
