
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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [EndpointDescription("Metodo para recepcionar mercancia con nuevas existencias")]
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
                            Quantity = d.Quantity,
                            Serial = d.Serial,
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

        [EndpointDescription("Registrar documentos con cambios de saldos recientes")]
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

        [EndpointDescription("Registrar extracto bancario")]
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

        [EndpointDescription("Obtener relacion de pagos aprobados")]
        [HttpGet("GetPayments_Consolidated")]
        public async Task<IActionResult> GetPayments_Consolidated(  [FromHeader(Name = "X-API-KEY")] string apiKey,  string supplierVat)
        {
            try
            {
                var response = new Models.Response<List<PaymentFull>>();

                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }


                // Obtener fuentes
                var documentTask = _dTransaction.GetPayment_Receipt(supplierVat);
                var detailTask = _dTransaction.GetAccount_Consolidated(supplierVat);
                var paymentTask = _dTransaction.GetPayments_Consolidated(supplierVat);


                await Task.WhenAll(documentTask, detailTask, paymentTask);


                var documentResponse = documentTask.Result;
                var detailResponse = detailTask.Result;
                var paymentResponse = paymentTask.Result;


                if (documentResponse.Data == null)
                {
                    return Ok(new Models.Response<List<PaymentFull>>
                    {
                        Data = new List<PaymentFull>(),
                        Message = "No hay datos",
                        Status = 200
                    });
                }


                // Lookups por IdPayment

                var detailLookup = detailResponse.Data?
                    .ToLookup(x => x.PaymentId);


                var paymentLookup = paymentResponse.Data?
                    .ToLookup(x => x.PaymentId);



                // Construcción final

                var paymentsFull = documentResponse.Data
                    .Select(doc =>
                    {

                        var PaymentId = doc.PaymentId;


                        return new PaymentFull
                        {
                            // Cabecera
                            Document = doc,


                            // Detalles relacionados
                            DocumentDetail = detailLookup?
                                [PaymentId]
                                .ToList()
                                ?? new List<DocumentDetail>(),


                            // Pagos relacionados
                            PaymentDetails = paymentLookup?
                                [PaymentId]
                                .ToList()
                                ?? new List<PaymentDetails>()
                        };


                    })
                    .ToList();



                return Ok(new Models.Response<List<PaymentFull>>
                {
                    Data = paymentsFull,
                    Status = 200,
                    Total = paymentsFull.Count
                });


            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status409Conflict,
                    ex.Message
                );
            }
        }



        [EndpointDescription("Obtener relacion de retenciones aprobados")]
        [HttpGet("GetRetention_Consolidated")]
        [ProducesResponseType(typeof(Models.Response<List<RetentionFull>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Models.Response<List<RetentionFull>>>> GetRetention_Consolidated(  [FromHeader(Name = "X-API-KEY")] string apiKey, string supplierVat)
        {
            try
            {

                var response = new Models.Response<Models.Result>();

                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }


                // Obtener datos
                var documentTask = _dTransaction.GetRetention_Consolidated(supplierVat);
                var detailTask = _dTransaction.GetAccount_Retention(supplierVat);


                await Task.WhenAll(documentTask, detailTask);


                var documentResponse = documentTask.Result;
                var detailResponse = detailTask.Result;


                if (documentResponse.Data == null)
                {
                    return Ok(new Models.Response<List<RetentionFull>>
                    {
                        Data = new List<RetentionFull>(),
                        Message = "No hay datos",
                        Status = 200
                    });
                }



                // Lookup de detalles por IdPayment
                var detailLookup = detailResponse.Data?
                    .ToLookup(x => x.PaymentId);



                var retentionFullList = documentResponse.Data
                    .Select(doc =>
                    {

                        var paymentId = doc.PaymentId;


                        return new RetentionFull
                        {

                            // Cabecera de retención
                            Document = doc,


                            // Detalles relacionados
                            DocumentDetail = detailLookup?
                                [paymentId]
                                .ToList()
                                ?? new List<DocumentDetailRetention>(),


                            // Retención no tiene pagos
                            PaymentDetails = new List<PaymentDetails>()

                        };


                    })
                    .ToList();



                return Ok(new Models.Response<List<RetentionFull>>
                {
                    Data = retentionFullList,
                    Status = 200,
                    Total = retentionFullList.Count
                });

            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status409Conflict,
                    ex.Message
                );
            }
        }

        [EndpointDescription("Confirmacion de relacion de pagos recibidos")]
        [HttpPost("PostAsincPayment")]
        public async Task<IActionResult> PostAsincPayment([FromHeader(Name = "X-API-KEY")] string apiKey, List<Models.AsincPayment> _list)
        {
            try
            {
                var response = new Models.Response<Models.Result>();
                if (apiKey != Util.Setting.ApiKey)
                {
                    response.SetError(new Exception("API KEY INVALIDA"));
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
                response = await _dTransaction.PostAsincPayment(_list);
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
