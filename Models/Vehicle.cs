using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    public class Vehicle 
    {

        [Required(ErrorMessage = "El ReceptionNumber es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string? ReceptionNumber { get; set; }

        [Required(ErrorMessage = "El ReceptionDate es obligatorio")] 
        public DateTime? ReceptionDate { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "El SupplierVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? SupplierVat { get; set; }

        [Required] public List<VehicleDetail> VehicleDetail { get; set; } = new();

    }


    public class VehicleDetail
    {
        [Required(ErrorMessage = "El Vin es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string? Vin { get; set; }

        [Required(ErrorMessage = "El Serial es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string? Serial { get; set; }

        [Required(ErrorMessage = "El Color es obligatorio")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "El ModelName es obligatorio")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? ModelName { get; set; }
        [Required(ErrorMessage = "El Year es obligatorio")] public Int32? Year { get; set; }


    }


    public class VehicleDispatch
    {
        [Required(ErrorMessage = "El Vin es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string? Vin { get; set; }

        [Required(ErrorMessage = "El SupplierVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? SupplierVat { get; set; }

        [Required(ErrorMessage = "El DealerCode es obligatorio")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? DealerCode { get; set; }

        [Required(ErrorMessage = "El Date es obligatorio")]  
        public DateTime? Date { get; set; } = DateTime.Now;


    }

}
