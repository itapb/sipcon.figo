using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    public class Model:Record   

    {


        [Required(ErrorMessage = "El Description es obligatorio")] [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")] [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El Description es obligatorio")] [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")] [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
         public string? Name { get; set; }

        [Required(ErrorMessage = "El SupplierVat es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public String? SupplierVat { get; set; }


    }
}
