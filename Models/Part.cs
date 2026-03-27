using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Part
    {
        [Required] public string? InnerCode { get; set; } = string.Empty;
        [Required] public string? MasterCode { get; set; } = string.Empty;

        [Required] public string? AlterCode { get; set; } = string.Empty;
        [Required] public string? Description { get; set; } = string.Empty;

        [Required] public string? AlterDescription { get; set; } = string.Empty;
        [Required] public string? TypeName { get; set; } = string.Empty;
        [Required] public string? FamilyName { get; set; } = string.Empty;
        [Required] public string? SubFamilyName { get; set; } = string.Empty;

        [Required] public decimal? Price { get; set; } = 0;
        [Required] public decimal? Cost { get; set; } = 0;

        [Required] public string? SupplierVat { get; set; } = string.Empty;
        [Required] public decimal? Tax { get; set; } = 0;

    }
}
