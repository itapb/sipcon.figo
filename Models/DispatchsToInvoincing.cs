using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class DispatchsToInvoincing
    {
        [SwaggerIgnore] public string? Reference { get; set; } = string.Empty;
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;
        [SwaggerIgnore] public string? DealerVat { get; set; } = string.Empty;
        [SwaggerIgnore] public string? InnerCode { get; set; } = string.Empty;
        [SwaggerIgnore] public int? Quantity { get; set; }
    }
}
