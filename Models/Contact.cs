using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Models
{
    public class Contact 
    {
        [Required] public string? Vat { get; set; } = string.Empty;
        [SwaggerIgnore]  public string? CustomerName { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Address { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Phone1 { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Phone2 { get; set; } = string.Empty;  
        [SwaggerIgnore] public string? Email { get; set; } = string.Empty;
        [SwaggerIgnore] public string? CityName { get; set; } = string.Empty;
        [SwaggerIgnore] public string? State { get; set; } = string.Empty;
        [SwaggerIgnore] public string? Male { get; set; } 
        [SwaggerIgnore]  public DateTime? Birthday { get; set; } = DateTime.Now;


    }
}
