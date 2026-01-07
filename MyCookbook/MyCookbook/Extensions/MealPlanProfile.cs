using AutoMapper;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.MealPlanDTOs;

namespace MyCookbook.Extensions
{
    public class MealPlanProfile : Profile
    {
        public MealPlanProfile()
        {
            CreateMap<MealPlan, MealPlanDetailDto>();
            CreateMap<MealPlanDay, MealPlanDayDto>();
            CreateMap<MealPlanRecipe, MealPlanRecipeDto>();
        }
    }
}
