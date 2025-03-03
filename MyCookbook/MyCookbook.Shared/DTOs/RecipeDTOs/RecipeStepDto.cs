using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class RecipeStepDto
    {
        public int Id { get; set; }
        public int StepNumber { get; set; } 
        public string Description { get; set; } = string.Empty;
    }
}
