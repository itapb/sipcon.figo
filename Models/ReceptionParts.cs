using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ReceptionParts
    { 
        [Required] public string? ReceptionDate { get; set; } = string.Empty;
        [Required] public string? ReceptionNumber { get; set; } = string.Empty;
        [Required] public string? SupplierVat { get; set; } = string.Empty;
        [Required] public string? ProviderVat { get; set; } = string.Empty;
        [Required] public List<Details> Detail { get; set; } = new();
    }
}
