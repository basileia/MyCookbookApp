using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook.Shared.DTOs.CategoryDTOs
{
    public class SelectableCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
    }
}
