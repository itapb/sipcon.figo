using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models
{
    public class InvoicedDispatchesDetail: Details
    {
        [Required(ErrorMessage = "Precio unitario de facturación es obligatorio")] public decimal? Price { get; set; }
        [Required(ErrorMessage = "El % de impuesto aplicado es obligatorio")] public decimal? Tax { get; set; }  
    }
}
