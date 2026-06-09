using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Representa la información de los documentos con saldos pendientes
    /// </summary>
    public class AccountReceivable
    {
        /// <summary>Rif de la planta</summary>
        [Required(ErrorMessage = "El SupplierVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? SupplierVat { get; set; } = string.Empty;

        /// <summary>Rif del concesionario</summary>
        [Required(ErrorMessage = "El DealerVat es obligatorio")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? DealerVat { get; set; } = string.Empty;

        /// <summary>Rubro o porcion del saldo: "B" Base, "I" Iva, "P" Placa</summary>
        [Required(ErrorMessage = "Concept es  obligatorio")][MaxLength(1, ErrorMessage = "Máximo 1 caracteres")] 
        public string? Concept { get; set; } = string.Empty;

        /// <summary>Tipo de documento o factura, "U" Unidades, "R" Repuestos, "P" Proforma, "G" Gastos Admin, "O" Otros </summary>
        [Required(ErrorMessage = "Type es  obligatorio")][MaxLength(1, ErrorMessage = "Máximo 1 caracteres")]
        public string? Type { get; set; } = string.Empty;

        /// <summary>Numero de Factura o documento</summary>
        [Required(ErrorMessage = "El Number es obligatorio")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string? Number { get; set; } = string.Empty;

        /// <summary>Nro de referencia de factura,opcional </summary>
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string? Reference { get; set; } = string.Empty;

        /// <summary>Fecha de emision del documento o factura</summary>
        [Required(ErrorMessage = "Date es obligatoria")] public DateTime? Date { get; set; }

        /// <summary>Fecha de vencimiento del documento o factura</summary>
        [Required(ErrorMessage = "DueDate es obligatoria")] public DateTime? DueDate { get; set; }

        /// <summary>Saldo pendiente en Dolares, del rubro o porcion, del documento o factura</summary>
        [Required(ErrorMessage = "Balance O Saldo es obligatorio")] public decimal Balance { get; set; } = 0;

        /// <summary>Tasa dolar del documento o factura, del dia de la emision</summary>
        [Required(ErrorMessage = "Rate es obligatorio")] public decimal Rate { get; set; }
        /// <summary>Monto total en Dolares, del documento o factura</summary>
        public decimal AmountFull { get; set; }

        // atributos nuevos de la factura
        public string Serie { get; set; } = "";
        public string Control { get; set; } = "";
        public decimal Tax { get; set; }
        public decimal Base { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountNonTax { get; set; }

    }


    public class DocumentDetail
    {
        public int Id { get; set; }


        /// <summary>NU_RECIBO_COBRO / PRI_NU_PLANILLA</summary>
        public int? PaymentId { get; set; }


        /// <summary>CTV_CO_TIPO_DOCUMENTO ,(FAC,NDB,NDN)</summary>
        public string? Type { get; set; } = string.Empty;


        /// <summary>CONCEPTO, (B,I,P,R)</summary>
        public string? Concept { get; set; } = string.Empty;

        /// <summary>NU_DOCUMENTO</summary>
        public string? Number { get; set; } = string.Empty;

        /// <summary>Nro de referencia de factura,opcional </summary>
        public string? Reference { get; set; } = string.Empty;


        /// <summary>MN_ABONO-  MN_ABONADO_A_DOC  </summary>
        public decimal Amount { get; set; }

        /// <summary>FC_TASA_CAMBIO</summary>
        public decimal AmountRate { get; set; }

        /// <summary>FE_TASA_CAMBIO</summary>
        public DateTime? DateRate { get; set; }


        // atributos nuevos de la factura
        public string Serie { get; set; } = "";
        public string Control { get; set; } = "";
        public decimal Tax { get; set; }
        public decimal WithholdTax { get; set; }
        public decimal Base { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountNonTax { get; set; }
        public decimal Sust { get; set; }
        public int Secuence { get; set; }

    }


    public class DocumentDetailRetention
    {
        public int Id { get; set; }


        /// <summary>NU_RECIBO_COBRO / PRI_NU_PLANILLA</summary>
        public int? PaymentId { get; set; }


        /// <summary>CTV_CO_TIPO_DOCUMENTO ,(FAC,NDB,NDN)</summary>
        public string? Type { get; set; } = string.Empty;


        /// <summary>CONCEPTO, (B,I,P,R)</summary>
        public string? Concept { get; set; } = string.Empty;

        /// <summary>NU_DOCUMENTO</summary>
        public string? Number { get; set; } = string.Empty;

        /// <summary>Nro de COMPROBANTE DE RETENCION APLICADO </summary>
        public string? Reference { get; set; } = string.Empty;


        /// <summary>MN_ABONO-  MN_ABONADO_A_DOC  </summary>
        public decimal Amount { get; set; }

        /// <summary>FC_TASA_CAMBIO</summary>
        public decimal AmountRate { get; set; }

        /// <summary>FE_TASA_CAMBIO</summary>
        public DateTime? DateRate { get; set; }

        /// <summary>FECHA EMISION</summary>
        public DateTime? Date { get; set; }


        // atributos nuevos de la factura
        public string Serie { get; set; } = "";
        public string Control { get; set; } = "";
        public decimal Tax { get; set; }
        public decimal WithholdTax { get; set; }
        public decimal Base { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountNonTax { get; set; }

        public decimal Sust { get; set; }

        public int Secuence { get; set; }

    }
}
