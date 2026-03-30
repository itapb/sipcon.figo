using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ReceptionParts
    { 
        [Required(ErrorMessage = "Fecha de recepción de los repuestos es obligatoria")] public string? ReceptionDate { get; set; } = string.Empty;
        [Required(ErrorMessage = "Número de documento de recepción es obligatorio")][MaxLength(10, ErrorMessage = "Máximo 10 caracteres")] public string? ReceptionNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Rif de la planta es obligatorio")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")] public string? SupplierVat { get; set; } = string.Empty;
        [Required(ErrorMessage = "Rif del proveedor es obligatorio")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")] public string? ProviderVat { get; set; } = string.Empty;
        [Required] public List<Details> Detail { get; set; } = new();
    }
}
