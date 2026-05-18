using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    /// <summary>
    /// Representa la información de los pagos
    /// </summary>
    public class PaymentDetails 
    {

        /// <summary>Id del detalle de pago</summary>
        public int? Id { get; set; }

        /// <summary>Id de la transaccion de relacion de pago</summary>
        public int? PaymentId { get; set; }

        /// <summary>Fecha del pago</summary>
        [Required] public DateTime? Date { get; set; }

        /// <summary>Monto del pago</summary>
        [Required] public decimal? Amount { get; set; }

        /// <summary>Tasa del pago</summary>
        [Required] public decimal? Rate { get; set; }

        /// <summary>Fecha de la tasa del pago</summary>
        [Required] public DateTime? DateRate { get; set; }

        /// <summary>Nombre de la moneda del pago</summary>
        [SwaggerIgnore] public string? CurrencyName { get; set; }

        /// <summary>Forma de pago</summary>
        [SwaggerIgnore] public string? TypeName { get; set; }

        /// <summary>Referencia de pago</summary>
        [Required] public string? Reference { get; set; }

        /// <summary>Nombre del banco Receptor</summary>
        [SwaggerIgnore] public string? BankName { get; set; }

        /// <summary>Numero de cuenta del banco receptor</summary>
        [SwaggerIgnore] public string? AccountNumber { get; set; }

        /// <summary>Nombre del banco Emisor</summary>
        [SwaggerIgnore] public string? BankOriginName { get; set; }

        /// <summary>Nombre de Concesionario responsable del pago</summary>
        [SwaggerIgnore] public string? DealerName { get; set; }

        /// <summary>Rif de Concesionario responsable del pago</summary>
        [SwaggerIgnore] public string? DealerVat { get; set; }

        /// <summary>Estatus interno del pago</summary>
        [SwaggerIgnore] public string? StatusName { get; set; }

    }


    public class PaymentFull 
    {
        public List<PaymentDetails>? PaymentDetails { get; set; } = new List<PaymentDetails>();
        public List<GetAccountReceivable>? AccountReceivable { get; set; } = new List<GetAccountReceivable>();

    }


    public class Settlements
    {
        [Required] public int? PaymentId { get; set; }

        [Required] public int? AccountReceivableId { get; set; }

    }

    public class Retention
    {
        /// <summary>Id del detalle de la retencion</summary>
        public int? Id { get; set; }

        /// <summary>Id de la tranasacion de relacion de retencion</summary>
        public int? PaymentId { get; set; }

        /// <summary>Fecha de la retencion</summary>
        [Required] public DateTime? Date { get; set; }

        /// <summary>Numero de referencia del comprobante de retencion</summary>
        [Required] public string? Reference { get; set; }

        /// <summary>Nombre del concesionario responsable de la retencion</summary>
        [SwaggerIgnore] public string? DealerName { get; set; }

        /// <summary>Rif del concesionario responsable de la retencion</summary>
        [SwaggerIgnore] public string? DealerVat { get; set; }

        [SwaggerIgnore] public string? StatusName { get; set; }

    }
    public class RetentionFull
    {
        public List<Retention>? Retentions { get; set; } = new List<Retention>();
        public List<GetAccountReceivable>? AccountReceivable { get; set; } = new List<GetAccountReceivable>();

    }

    public class AsincPayment
    {
        [Required] public int? PaymentId { get; set; }
        [Required] public string? SupplierVat { get; set; }

    }


}
