using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    public class Vehicle 
    {

        [SwaggerIgnore] public string? Vin { get; set; }
        [SwaggerIgnore] public string? EngineSerial { get; set; }
        [SwaggerIgnore] public string? Plate { get; set; }
        [SwaggerIgnore] public string? ColorName { get; set; }
        [SwaggerIgnore] public string? ModelName { get; set; }
        [Required] public Int32? Year { get; set; }
        [SwaggerIgnore] public string? DealerName { get; set; }
        [SwaggerIgnore] public String? PolicyEstatus { get; set; }
        [SwaggerIgnore] public DateTime? LockDate { get; set; }
        [SwaggerIgnore] public DateTime? ActivationDate { get; set; }
        [SwaggerIgnore] public DateTime? ExpirationDate { get; set; }


    }

    public class General
    {
        public Models.Vehicle? Vehicle { get; set; }
        public Models.Contact? Customer { get; set; }

    }

}
