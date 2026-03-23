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
        

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Name { get; set; }

   
        [SwaggerIgnore]
        public String? SupplierVat { get; set; }


    }
}
