using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Models
{
    public class Contact 
    {
        [Required(ErrorMessage = "El Vat es obligatorio")] [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")] [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string? Vat { get; set; } = string.Empty;

        [Required(ErrorMessage = "El FirstName es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(100, ErrorMessage = "Máximo 100 caracteres")] 
        public string? FirstName { get; set; } = string.Empty;
         public string? LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Address es obligatorio")][MinLength(5, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(250, ErrorMessage = "Máximo 250 caracteres")] 
        public string? Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "El CityName es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(30, ErrorMessage = "Máximo 30 caracteres")] 
        public string? CityName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Phone1 es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")] 
         public string? Phone1 { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Máximo 12 caracteres")] public string? Phone2 { get; set; } = string.Empty; 
        

        [Required(ErrorMessage = "El Email es obligatorio")] [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")] [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Email { get; set; } = string.Empty;
        
        public DateTime? Birthday { get; set; } = DateTime.Now;

         public bool? Male { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")] public string? Reference { get; set; } = string.Empty;

        [Required(ErrorMessage = "El SupplierVat es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")] 
        public string? SupplierVat { get; set; } = string.Empty;

         public bool? IsCustomer { get; set; } = false;
         public bool? IsDealer { get; set; } = false;
         public bool? IsProvider { get; set; } = false;



    }
}
