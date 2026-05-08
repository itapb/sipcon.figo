using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Rate
    {
        [Required] public DateTime RateDate { get; set; }
        [Required] public decimal RateValue { get; set; }

    }
}
