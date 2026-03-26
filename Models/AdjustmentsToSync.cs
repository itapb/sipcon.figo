using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AdjustmentsToSync
    {
        [SwaggerIgnore] public int? AdjustmentNumber { get; set; } 
        [SwaggerIgnore] public string? AdjustmentDate { get; set; } = string.Empty;
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Observation { get; set; } = string.Empty;
        [SwaggerIgnore] public string? InnerCode { get; set; } = string.Empty;
        [SwaggerIgnore] public int? Quantity { get; set; }
        [SwaggerIgnore] public string? Type { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Concept { get; set; } = string.Empty;
    }
}
