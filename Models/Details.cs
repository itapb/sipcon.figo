using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Details
    {
        [Required(ErrorMessage = "Código de respuesto es obligatorio")][MaxLength(25, ErrorMessage = "Máximo 25 caracteres")] public string? InnerCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Cantidad de repuesto es obligatoria")] public int? Quantity { get; set; }
    }
}
