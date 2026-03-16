
using Azure;
using ClosedXML.Excel;
using Data;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Models;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.Controllers
{
    [Route("api/Vehicle")]
    [ApiController]
    public class cVehicle : ControllerBase
    {

      
        private readonly dVehicle _dVehicle;
        
        public cVehicle(dVehicle dVehicle)
        {
            _dVehicle = dVehicle;
          
        }


        [HttpGet("Vehicle")]
        public async Task<IActionResult> GetGeneralByCredentials([FromHeader(Name = "X-API-KEY")] string apiKey, String vat, String plate)
        {
            var response = new Models.Response<Models.General>();

            try
            {
                // Validar API Key
                if (apiKey != Util.Setting.ApiKey) 
                { 
                    response.SetError(new Exception("API KEY INVALIDA")); 
                    return StatusCode(StatusCodes.Status401Unauthorized, response); 
                }

                var vehicleResponse = await _dVehicle.GetVehicleBy(vat,plate);
                var customerResponse = await _dVehicle.GetCustomerBy(vat,plate);

                if (vehicleResponse.Data?.Vin == null || customerResponse.Data?.Vat == null)
                {
                    response.SetError(new Exception("ERROR DE AUTENTICACION: CONSULTE CON EL ADMINISTRADOR"));
                    return StatusCode(response.Status, response);
                }

                var general = new Models.General
                {
                    Vehicle = vehicleResponse.Data,
                    Customer = customerResponse.Data
                };

                response.Data = general;
                response.Total = 1;
                response.Processed = true;

                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                response.Processed = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
        }


        [HttpGet("GetServiceRecord")]
        public async Task<IActionResult> GetServiceRecord(string plate, [FromHeader(Name = "X-API-KEY")] string apiKey)
        {
            var response = new Models.Response<Models.Services>();
            try
            {
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }

                var _response = await _dVehicle.GetServiceRecord(plate);

                // Clasificamos los servicios
                var services = new Services
                {
                    Maintenances = _response.Data
                        .Where(s => s.ServiceTypeId == 1) // ejemplo: 1 = mantenimiento
                        .ToList(),

                    FailReports = _response.Data
                        .Where(s => s.ServiceTypeId == 3) // ejemplo: 3 = reporte de falla
                        .ToList()
                };

                response.Data = services;
                response.Total = 1;
                response.Processed = true;

                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }





    }
}
