using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class PlatesToAssign
    {
        [SwaggerIgnore] public string? Plate { get; set; } = string.Empty; 
        [SwaggerIgnore] public string? Vin { get; set; } = string.Empty;
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;  
    }
}
