using AutoMapper;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs.UserRecipeStatusDTOs;

namespace MyCookbook.Extensions
{
    public class UserRecipeStatusProfile : Profile
    {
        public UserRecipeStatusProfile()
        {
            CreateMap<UserRecipeStatus, UserRecipeStatusDto>().ReverseMap();
        }
    }
}
