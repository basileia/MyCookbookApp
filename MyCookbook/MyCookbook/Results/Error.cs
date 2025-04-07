using System;
using System.Collections.Generic;
namespace MyCookbook.Results
{
    public record Error
    {
        public string Code { get; set; }  
        public string? Details { get; set; }

        public Error(string code, string? details = null)
        {
            Code = code;
            Details = details;
        }
    }
}
