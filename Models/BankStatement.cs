using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Representa la información de los extractos bancarios
    /// </summary>
    public class BankStatement
    {
        /// <summary>Nro Cuenta Bancaria</summary>
        [Required] public String? BankAccount { get; set; }

        /// <summary>Codigo de 4 caracteres que identifica el Banco</summary>
        [Required] public String? BankCode { get; set; }

        /// <summary>Fecha de la transaccion del banco</summary>
        [Required] public DateTime? TransactionDate { get; set; }

        /// <summary>Numero de referencia de la transaccion</summary>
        [Required] public String? Reference { get; set; }

        /// <summary>Monto de la transaccion bancaria</summary>
        [Required] public decimal? Amount { get; set; }

    }
}
