﻿namespace MyCookbook.Shared.DTOs
{
    public class UpdateUserRecipeStatusDto
    {
        public int RecipeId { get; set; }
        public bool? IsTried { get; set; }
        public bool? IsFavourite { get; set; }
    }
}
