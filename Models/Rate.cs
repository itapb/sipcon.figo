using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Representa la información de la tasa de dolar alterna
    /// </summary>
    public class Rate
    {
        /// <summary>Dia de la tasa</summary>
        [Required] public DateTime RateDate { get; set; }

        /// <summary>Valor de la tasa para el dia indicado</summary>
        [Required] public decimal RateValue { get; set; }

    }
}
