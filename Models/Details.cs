using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Details
    {
        public string? InnerCode { get; set; } = string.Empty;
        public int? Quantity { get; set; }
    }
}
