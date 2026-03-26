using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AdjustmentsToSyncWithContext
    {
        [SwaggerIgnore] public int? AdjustmentNumber { get; set; }
        [SwaggerIgnore] public string? AdjustmentDate { get; set; } = string.Empty;
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Observation { get; set; } = string.Empty;
        [SwaggerIgnore] public List<AdjustmentsDetailsToSync> Detail { get; set; } = new();
    }
}
