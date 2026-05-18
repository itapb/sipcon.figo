using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Representa la información del numero de ajuste sincronizado
    /// </summary>
    public class SyncAdjustment
    {
        [Required(ErrorMessage = "Número del ajuste sincronizado es obligatorio")] public int? AdjustmentNumber { get; set; }
    }
}
