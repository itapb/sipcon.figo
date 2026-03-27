
using Azure;
using ClosedXML.Excel;
using Data;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Models;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.Controllers
{
    [Route("api/Master")]
    [ApiController]
    public class cMaster : ControllerBase
    {

      
        private readonly dMaster _dMaster;
        
        public cMaster(dMaster dMaster)
        {
            _dMaster = dMaster;
          
        }

        [HttpPost("PostParts")]
        public async Task<IActionResult> PostParts([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.Part> _parts)
        {

            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }

                response = await _dMaster.PostParts(_parts);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }

        }

        [HttpPost("PostContacts")]
        public async Task<IActionResult> PostContacts([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.Contact> _contacts)
        {

            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                var error = "";
                foreach (var contact in _contacts)
                {
                    if ((contact.Vat.Substring(0, 1).ToUpper() == "V") || (contact.Vat.Substring(0, 1).ToUpper() == "E"))
                    {
                        if (string.IsNullOrEmpty(contact.LastName))
                        {
                            error = "Dato Apellido, es requerido para: " + contact.FirstName;
                            throw new Exception(error);
                        }
                    }
                    else
                    {
                        contact.LastName = string.Empty;
                    }

                }

                response = await _dMaster.PostContacts(_contacts);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }

        }
         #endregion

        #region MODELOS
        [HttpPost("PostModels")]
        public async Task<IActionResult> Post_Models([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.Model> models)
        {

            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                 response = await _dMaster.Post_Models(models);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region LISTA PRECIOS
        [HttpPost("PostPriceList")]
        public async Task<IActionResult> PostPriceList(
         [FromHeader(Name = "X-API-KEY")] string apiKey,
         List<Models.PriceList> priceList)
            {
                try
                {
                    var response = new Models.Response<Models.Result>();
                    if (apiKey != Util.Setting.ApiKey)
                    {
                        response.SetError(new Exception("API KEY INVALIDA"));
                        return StatusCode(StatusCodes.Status401Unauthorized, response);
                    }
                    response = await _dMaster.PostPriceList(priceList);
                    return StatusCode(response.Status, response);
                }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion




    }
}
