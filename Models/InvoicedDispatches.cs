using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class InvoicedDispatches
    {
        [Required] public string? Reference { get; set; } = string.Empty; 
        [Required] public string? InvoicedNumber { get; set; } = string.Empty;
        [Required] public string? SupplierVat { get; set; } = string.Empty; 
        [Required] public List<InvoicedDispatchesDetail> Detail { get; set; } = new();
    }
}
