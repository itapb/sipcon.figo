using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class PriceList  
    {
        [Required] public string? SupplierVat { get; set; } = string.Empty;
        [Required] public string? InnerCode { get; set; } = string.Empty;
        [Required] public decimal? Price { get; set; }
        [Required] public decimal? Cost { get; set; }
    }
}
