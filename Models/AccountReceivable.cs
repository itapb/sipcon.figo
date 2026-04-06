using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AccountReceivable
    {
        [Required(ErrorMessage = "El SupplierVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? SupplierVat { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El DealerVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? DealerVat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Concept es  obligatorio")][MaxLength(1, ErrorMessage = "Máximo 1 caracteres")] public string? Concept { get; set; } = string.Empty;
        [Required(ErrorMessage = "Type es  obligatorio")][MaxLength(1, ErrorMessage = "Máximo 1 caracteres")] public string? Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Number es obligatorio")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string? Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Reference es obligatorio")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string? Reference { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date es obligatoria")] public DateTime? Date { get; set; } 
        [Required(ErrorMessage = "DueDate es obligatoria")] public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "Balance es obligatorio")] public decimal Balance { get; set; } = 0;
        [Required(ErrorMessage = "Amount es obligatorio")] public decimal Amount { get; set; }
        [Required(ErrorMessage = "Rate es obligatorio")] public decimal Rate { get; set; }
    }
}
