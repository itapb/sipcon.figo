using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Models
{
    public class Contact 
    {
        [Required] public string? Vat { get; set; } = string.Empty;
        [Required] public string? FirstName { get; set; } = string.Empty;
        [Required] public string? LastName { get; set; } = string.Empty;
        [Required] public string? Address { get; set; } = string.Empty;
        [Required] public string? CityName { get; set; } = string.Empty;
        [Required] public string? Phone1 { get; set; } = string.Empty;
                   public string? Phone2 { get; set; } = string.Empty;  
        [Required] public string? Email { get; set; } = string.Empty;
        [Required] public DateTime? Birthday { get; set; } = DateTime.Now;
                   public string? Male { get; set; }
                   public string? Reference { get; set; } = string.Empty;
        [Required] public string? SupplierVat { get; set; } = string.Empty;
         public bool? IsCustomer { get; set; } = false;
         public bool? IsDealer { get; set; } = false;
         public bool? IsProvider { get; set; } = false;



    }
}
