using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    public class Services
    {
       public List<Service>? Maintenances { get; set; }
       public List<Service>? FailReports { get; set; }

    }

    public class Service
    {
        //Datos de Servicio
        [SwaggerIgnore] public Int32? ServiceId { get; set; }
        [Required] public Int32? ServiceTypeId { get; set; }
        [SwaggerIgnore] public String? ServiceTypeName { get; set; }
        [SwaggerIgnore] public String? ReportTypeName { get; set; }
        [Required] public DateTime? ServiceDate { get; set; }
        [SwaggerIgnore] public String? DealerServiceName { get; set; }
        [Required] public Int32? Km { get; set; }


    }
    

}