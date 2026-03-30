using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class InvoicedDispatches
    {
        [Required(ErrorMessage = "Codigo de referencia del despacho es obligatorio")][MaxLength(10, ErrorMessage = "Máximo 10 caracteres")] public string? Reference { get; set; } = string.Empty; 
        [Required(ErrorMessage = "Número de factura es obligatorio")] public int? InvoicedNumber { get; set; } 
        [Required(ErrorMessage = "Fecha de factura es obligatoria")] public string? InvoicedDate { get; set; } = string.Empty;
        [Required(ErrorMessage = "Rif de la planta es obligatorio")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")] public string? SupplierVat { get; set; } = string.Empty;
        [Required] public List<InvoicedDispatchesDetail> Detail { get; set; } = new();
    }
}
