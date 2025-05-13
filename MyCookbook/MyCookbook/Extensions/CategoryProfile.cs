using AutoMapper;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.CategoryDTOs;

namespace MyCookbook.Extensions
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
