
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
    [Route("api/Transaction")]
    [ApiController]
    public class cTransaction : ControllerBase
    {
        private readonly dTransaction _dTransaction;

        public cTransaction(dTransaction dTransaction)
        {
            _dTransaction = dTransaction;
        }

        #region RECEPCION DE REPUESTOS
        [HttpPost("PostReceptionParts")]
        public async Task<IActionResult> PostReceptionParts(
        [FromHeader(Name = "X-API-KEY")] string apiKey,
        List<Models.ReceptionParts> receptionParts)
            {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostReceptionParts(receptionParts);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region DESPACHOS POR FACTURAR
        [HttpGet("GetDispatchsToInvoicing")]
        public async Task<IActionResult> GetDispatchsToInvoicing(
        [FromHeader(Name = "X-API-KEY")] string apiKey)
        {
            try
            {
                var response = new Models.Response<List<Models.DispatchsToInvoincing>>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }

                // Obtener lista plana
                var flat = await _dTransaction.GetDispatchsToInvoicing();
                 
                var grouped = flat.Data
                    .GroupBy(x => new { x.Reference, x.SupplierVat, x.DealerVat })
                    .Select(g => new Models.DispatchsToInvoincingWithContext
                    {
                        Reference = g.Key.Reference,
                        SupplierVat = g.Key.SupplierVat,
                        DealerVat = g.Key.DealerVat,
                        Detail = g.Select(d => new Models.Details
                        {
                            InnerCode = d.InnerCode,
                            Quantity = d.Quantity
                        }).ToList()
                    }).ToList();

                var result = new Models.Response<List<Models.DispatchsToInvoincingWithContext>>();
                result.Data = grouped;
                result.Total = flat.Total;
                result.Processed = flat.Processed;
                result.Message = flat.Message;

                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region DESPACHOS FACTURADOS
        [HttpPost("PostInvoicedDispatches")]
        public async Task<IActionResult> PostInvoicedDispatches(
        [FromHeader(Name = "X-API-KEY")] string apiKey,
        List<Models.InvoicedDispatches> invoicedDispatches)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostInvoicedDispatches(invoicedDispatches);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region PLACAS POR ASIGNAR
        [HttpGet("GetPlatesToAssign")]
        public async Task<IActionResult> GetPlatesToAssign(
        [FromHeader(Name = "X-API-KEY")] string apiKey, string supplierVat)
        {
            try
            {
                var response = new Models.Response<List<Models.PlatesToAssign>>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }

                var flat = await _dTransaction.GetPlatesToAssign(supplierVat);
                var result = new Models.Response<List<Models.PlatesToAssign>>();
                result.Total = flat.Total;
                result.Processed = flat.Processed;
                result.Message = flat.Message;
                result.Data = flat.Data;    

                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }

        [HttpPost("PostPlatesAssigned")]
        public async Task<IActionResult> PostPlatesAssigned([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.PlatesAssign> _list)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostPlatesAssigned(_list);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }


        #endregion



        #region  RECEPCION DE VEHICULOS


        [HttpPost("PostStatusVehicle")]
        public async Task<IActionResult> PostStatusVehicle([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.VehicleStatus> _list)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostStatusVehicle(_list);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }

        #endregion


        #region  DESPACHO DE VEHICULOS
        [HttpPost("PostVehicleDispatches")]
        public async Task<IActionResult> PostVehicleDispatches([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.VehicleDispatch> _list)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostVehicleDispatches(_list);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region AJUSTES POR SINCROIZAR
        [HttpGet("GetAdjustmentsToSync")]
        public async Task<IActionResult> GetAdjustmentsToSync(
        [FromHeader(Name = "X-API-KEY")] string apiKey)
        {
            try
            {
                var response = new Models.Response<List<Models.AdjustmentsToSync>>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }

                // Obtener lista plana
                var flat = await _dTransaction.GetAdjustmentsToSync();

                var grouped = flat.Data
                    .GroupBy(x => new { x.AdjustmentNumber, x.AdjustmentDate, x.SupplierVat, x.Observation })
                    .Select(g => new Models.AdjustmentsToSyncWithContext
                    {
                        AdjustmentNumber = g.Key.AdjustmentNumber,
                        AdjustmentDate = g.Key.AdjustmentDate,
                        SupplierVat = g.Key.SupplierVat,
                        Observation = g.Key.Observation,
                        Detail = g.Select(d => new Models.AdjustmentsDetailsToSync
                        {
                            InnerCode = d.InnerCode,
                            Quantity = d.Quantity,
                            Type = d.Type,
                            Concept = d.Concept
                        }).ToList()
                    }).ToList();

                var result = new Models.Response<List<Models.AdjustmentsToSyncWithContext>>();
                result.Data = grouped;
                result.Total = flat.Total;
                result.Processed = flat.Processed;
                result.Message = flat.Message;

                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region AJUSTES SINCRONIZADOS
        [HttpPost("PostSyncAdjustment")]
        public async Task<IActionResult> PostSyncAdjustment(
        [FromHeader(Name = "X-API-KEY")] string apiKey,
        List<Models.SyncAdjustment> syncAdjustment)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostSyncAdjustment(syncAdjustment);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region PORTAL DE PAGOS 
        [HttpPost("PostAccountReceivable")]
        public async Task<IActionResult> PostAccountReceivable( [FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.AccountReceivable> syncAdjustment)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostAccountReceivable(syncAdjustment);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }

        [HttpPost("PostBankStatement")]
        public async Task<IActionResult> PostBankStatement([FromHeader(Name = "X-API-KEY")] string apiKey, List<BankStatement> _list, string supplierVat)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostBankStatement(_list,supplierVat);
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
