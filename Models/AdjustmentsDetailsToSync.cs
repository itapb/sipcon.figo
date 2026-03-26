using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models
{
    public class AdjustmentsDetailsToSync : Details
    {
        [Required] public string? Type { get; set; } = string.Empty;
        [Required] public string? Concept { get; set; } = string.Empty;
    }
}
