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
        [Required] public decimal? Price { get; set; }  
        [Required] public decimal? Tax { get; set; }  
    }
}
