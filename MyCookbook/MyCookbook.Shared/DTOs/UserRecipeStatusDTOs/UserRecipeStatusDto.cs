﻿namespace MyCookbook.Shared.DTOs.UserRecipeStatusDTOs
{
    public class UserRecipeStatusDto
    {
        public int RecipeId { get; set; }
        public bool IsTried { get; set; }
        public bool IsFavourite { get; set; }
    }
}
