using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Representa la información de los despachos de repuestos por facturar
    /// </summary>
    public class DispatchsToInvoincingWithContext
    { 
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;
        [SwaggerIgnore] public string? DealerVat { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Reference { get; set; } = string.Empty; 
        [SwaggerIgnore] public List<Details> Detail { get; set; } = new();
    }
}
