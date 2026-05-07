using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    public class PaymentDetails 
    {
        public int? Id { get; set; }
        public int? PaymentId { get; set; }
        [Required] public DateTime? Date { get; set; }
        [Required] public decimal? Amount { get; set; }
        [Required] public decimal? Rate { get; set; }
        [Required] public DateTime? DateRate { get; set; }
        [SwaggerIgnore] public string? CurrencyName { get; set; }
        [SwaggerIgnore] public string? TypeName { get; set; }
        [Required] public string? Reference { get; set; }
        [SwaggerIgnore] public string? BankName { get; set; }
        [SwaggerIgnore] public string? AccountNumber { get; set; }
        [SwaggerIgnore] public string? BankOriginName { get; set; }
        [SwaggerIgnore] public string? DealerName { get; set; }
        [SwaggerIgnore] public string? DealerVat { get; set; }
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
        public int? Id { get; set; }
        public int? PaymentId { get; set; }
        [Required] public DateTime? Date { get; set; }
        [Required] public string? Reference { get; set; }
        [SwaggerIgnore] public string? DealerName { get; set; }
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
