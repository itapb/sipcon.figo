using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Representa la información de los despachos pendientes por facturar
    /// </summary>
    public class DispatchsToInvoincing
    {
        /// <summary>Nro de referencia del despacho pendiente por facturar</summary>
        [SwaggerIgnore] public string? Reference { get; set; } = string.Empty;

        /// <summary>Rif de la planta, origen del despacho</summary>
        [SwaggerIgnore] public string? SupplierVat { get; set; } = string.Empty;

        /// <summary>Rif del cliente o concesionario, quien recibe del despacho</summary>
        [SwaggerIgnore] public string? DealerVat { get; set; } = string.Empty;

        /// <summary>Codigo interno del respuesto despachado</summary>
        [SwaggerIgnore] public string? InnerCode { get; set; } = string.Empty;

        /// <summary>Cantidad despachada</summary>
        [SwaggerIgnore] public int? Quantity { get; set; }
        /// <summary>Serial del respueto despachado, en caso de aplicar</summary>
        [SwaggerIgnore] public string? Serial { get; set; } = string.Empty;
    }
}
