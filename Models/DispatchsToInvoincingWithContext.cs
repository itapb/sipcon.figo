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
        /// <summary>Nro de referencia del despacho pendiente por facturar</summary>
        [SwaggerIgnore] public string? Reference { get; set; } = string.Empty;

        /// <summary>Rif de la planta, origen del despacho</summary>
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;

        /// <summary>Rif del cliente o concesionario, quien recibe del despacho</summary>
        [SwaggerIgnore] public string? DealerVat { get; set; } = string.Empty;

        [SwaggerIgnore] public string? SaleOrderType { get; set; } = string.Empty;

        [SwaggerIgnore] public string? Comment { get; set; } = string.Empty;

        [SwaggerIgnore] public List<Details> Detail { get; set; } = new();
    }
}
