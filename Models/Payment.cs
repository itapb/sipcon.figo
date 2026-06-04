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


    public class Document
    {

        /// <summary>NU_DOCUMENTO </summary>
        public int? PaymentId { get; set; }

        /// <summary>EMP_CO_EMPRESA </summary>
        [SwaggerIgnore] public string? SupplierVat { get; set; }

        /// <summary>EMP_CO_EMPRESA </summary>
        [SwaggerIgnore] public string? DealerVat { get; set; }

        /// <summary>FE_FORMA_PAGO </summary>
        [Required] public DateTime? Date { get; set; }

        /// <summary>UNM_CO_UNIDAD_MONETARIA</summary>
        [SwaggerIgnore] public string? Currency { get; set; }

        /// <summary>CTV_CO_TIPO_DOCUMENTO</summary>
        [SwaggerIgnore] public string? DocumentType { get; set; }

        /// <summary>NUMERO COMPROBANTE RET/summary>
        [SwaggerIgnore] public string? Reference { get; set; }


    }


    public class PaymentDetails 
    {

        /// <summary>Id del detalle de pago</summary>
        public int? Id { get; set; }

        /// <summary>NU_DOCUMENTO </summary>
        public int? PaymentId { get; set; }

        /// <summary>EMP_CO_EMPRESA </summary>
        [SwaggerIgnore] public string? SupplierVat { get; set; }

        /// <summary>CTV_CO_TIPO_DOCUMENTO</summary>
        [SwaggerIgnore] public string? DocumentType { get; set; }

        /// <summary>(TRB,EFC) ,CTV_CO_TIPO_FORMA_PAGO </summary>
        [SwaggerIgnore] public string? PaymentType { get; set; }

        /// <summary>MN_FORMA_PAGO </summary>
        [Required] public decimal? Amount { get; set; }

        /// <summary>FE_FORMA_PAGO </summary>
        [Required] public DateTime? Date { get; set; }

        /// <summary>NU_REFERENCIA_FORMA_PAGO</summary>
        [Required] public string? Reference { get; set; }

        /// <summary>FC_TASA_CAMBIO</summary>
        [Required] public decimal? AmountRate { get; set; }

        /// <summary>FE_TASA_CAMBIO</summary>
        [Required] public DateTime? DateRate { get; set; }

        /// <summary>UNM_CO_UNIDAD_MONETARIA</summary>
        [SwaggerIgnore] public string? Currency { get; set; }

        /// <summary>NU_CUENTA_BANCARIA</summary>
        [SwaggerIgnore] public string? BankAccount { get; set; }

        /// <summary>ORG_CO_ENTIDAD_FINANCIERA</summary>
        [SwaggerIgnore] public string? BankVat { get; set; }



    }

    public class PaymentFull 
    {

        public required Document Document { get; set; }
        public List<DocumentDetail>? DocumentDetail { get; set; } = new List<DocumentDetail>();
        public List<PaymentDetails>? PaymentDetails { get; set; } = new List<PaymentDetails>();
       
    }

    public class RetentionFull
    {

        public required Document Document { get; set; }
        public List<DocumentDetailRetention>? DocumentDetail { get; set; } = new List<DocumentDetailRetention>();
        public List<PaymentDetails>? PaymentDetails { get; set; } = new List<PaymentDetails>();

    }


    public class AsincPayment
    {
        [Required] public int? PaymentId { get; set; }
        [Required] public string? SupplierVat { get; set; }

    }



}
