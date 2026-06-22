using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Refund
    {
        /// <summary>Rif de la planta</summary>
        [Required] public string? SupplierVat { get; set; } = string.Empty;

        /// <summary>Nro de Devolucion de figo</summary>
        [Required] public string? Reference { get; set; } = string.Empty;

        /// <summary>Codigo del respuesto devuelto</summary>
        [Required] public string? InnerCode { get; set; } = string.Empty;

        /// <summary>Cantidad Devuelta</summary>
        [Required] public int? Quantity { get; set; } 
    


    }
}
