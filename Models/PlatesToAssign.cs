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


    public class PlatesAssign
    {
        [Required(ErrorMessage = "El Vin es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string? Vin { get; set; } = string.Empty;

        [Required(ErrorMessage = "El SupplierVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? SupplierVat { get; set; } = string.Empty;
    }
}
