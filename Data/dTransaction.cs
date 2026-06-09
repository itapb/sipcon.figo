using DocumentFormat.OpenXml.EMMA;
using Models;
using System.Data;
using Util;

namespace Data
{
    public class dTransaction
    {
        private readonly SemaphoreSlim _semaphore;

        public dTransaction()
        {
            Util.Setting.GetSettings(true);
            _semaphore = new SemaphoreSlim(300, 500);
        }

        #region RECEPCION DE REPUESTOS
        public async Task<Response<Models.Result>> PostReceptionParts(List<Models.ReceptionParts> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostReceptionParts(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<Models.Result>> _PostReceptionParts(List<Models.ReceptionParts> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@DATA", _jsonstring);
                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_RECEPTIONPARTS_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }
        #endregion

        #region DESPACHOS POR FACTURAR
        public async Task<Response<List<Models.DispatchsToInvoincing>>> GetDispatchsToInvoicing()
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetDispatchsToInvoicing();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<List<Models.DispatchsToInvoincing>>> _GetDispatchsToInvoicing()
        {
            Response<List<Models.DispatchsToInvoincing>> _response = new Response<List<Models.DispatchsToInvoincing>>();
            try
            {
                Mapping _mapping = new Mapping();
                _mapping.AddItem("Reference", "IDCONTROL");
                _mapping.AddItem("SupplierVat", "VVATSUPPLIER");
                _mapping.AddItem("DealerVat", "VVATDEALER");
                _mapping.AddItem("InnerCode", "VINNERCODE");
                _mapping.AddItem("Quantity", "IDISPATCHED");
                _mapping.AddItem("Serial", "VSERIAL");

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_DISPATCHSTOINVOINCING_FIGO", null);
                _response.Data = _data.GetList<Models.DispatchsToInvoincing>(_mapping, _table);
                _response.SetGetResponse(_table);
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }
        #endregion

        #region DESPACHOS FACTURADOS
        public async Task<Response<Models.Result>> PostInvoicedDispatches(List<Models.InvoicedDispatches> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostInvoicedDispatches(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<Models.Result>> _PostInvoicedDispatches(List<Models.InvoicedDispatches> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@DATA", _jsonstring);
                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_INVOICEDDISPATCHES_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }
        #endregion

        #region PLACAS POR ASIGNAR
        public async Task<Response<List<Models.PlatesToAssign>>> GetPlatesToAssign(string supplierVat )
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetPlatesToAssign(supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<List<Models.PlatesToAssign>>> _GetPlatesToAssign(string supplierVat)
        {
            Response<List<Models.PlatesToAssign>> _response = new Response<List<Models.PlatesToAssign>>();
            try
            {
                Parameter _parameter = new Parameter();

                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);
                Mapping _mapping = new Mapping();
                _mapping.AddItem("Plate", "VPLATE");
                _mapping.AddItem("SupplierVat", "VVATSUPPLIER");
                _mapping.AddItem("Vin", "VVIN");
                _mapping.AddItem("Condition", "VCONDITION");
                _mapping.AddItem("Heavy", "BHEAVY");

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_PLATESTOASSIGN_FIGO", _parameter);
                _response.Data = _data.GetList<Models.PlatesToAssign>(_mapping, _table);
                _response.SetGetResponse(_table);
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

        public async Task<Response<Models.Result>> PostPlatesAssigned(List<Models.PlatesAssign> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostPlatesAssigned(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<Models.Result>> _PostPlatesAssigned(List<Models.PlatesAssign> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();

                _parameter.AddSqlParameter("@DATA", _jsonstring);

                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_PLATESASSIGN_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

        #endregion

        #region RECEPCION DE VEHICULOS

        public async Task<Response<Models.Result>> PostStatusVehicle(List<Models.VehicleStatus> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostStatusVehicle(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<Models.Result>> _PostStatusVehicle(List<Models.VehicleStatus> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();

                _parameter.AddSqlParameter("@DATA", _jsonstring);

                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_STATUS_VEHICLE_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

        #endregion

        #region DESPACHO DE VEHICULOS
        public async Task<Response<Models.Result>> PostVehicleDispatches(List<Models.VehicleDispatch> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostVehicleDispatches(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<Models.Result>> _PostVehicleDispatches(List<Models.VehicleDispatch> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();

                _parameter.AddSqlParameter("@DATA", _jsonstring);

                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_VEHICLEDISPATCHES_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }
        #endregion

        #region AJUSTES POR SINCROIZAR

        public async Task<Response<List<Models.AdjustmentsToSync>>> GetAdjustmentsToSync()
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetAdjustmentsToSync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<List<Models.AdjustmentsToSync>>> _GetAdjustmentsToSync()
        {
            Response<List<Models.AdjustmentsToSync>> _response = new Response<List<Models.AdjustmentsToSync>>();
            try
            {
                Mapping _mapping = new Mapping();
                _mapping.AddItem("AdjustmentNumber", "ID");
                _mapping.AddItem("AdjustmentDate", "DCREATED");
                _mapping.AddItem("SupplierVat", "VVATSUPPLIER");
                _mapping.AddItem("Observation", "VCOMMENT");
                _mapping.AddItem("InnerCode", "VINNERCODE");
                _mapping.AddItem("Quantity", "ISTOCK");
                _mapping.AddItem("Type", "CTYPE");
                _mapping.AddItem("Concept", "VDESCRIPTION");

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_ADJUSTMENTSTOSYNC_FIGO", null);
                _response.Data = _data.GetList<Models.AdjustmentsToSync>(_mapping, _table);
                _response.SetGetResponse(_table);
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

        #endregion

        #region AJUSTES SINCRONIZADOS
        public async Task<Response<Models.Result>> PostSyncAdjustment(List<Models.SyncAdjustment> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostSyncAdjustment(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<Models.Result>> _PostSyncAdjustment(List<Models.SyncAdjustment> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@DATA", _jsonstring);
                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_SYNCADJUSTMENT_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }
        #endregion

        #region PORTAL DE PAGOS 
        public async Task<Response<Models.Result>> PostAccountReceivable(List<Models.AccountReceivable> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostAccountReceivable(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        private async Task<Response<Models.Result>> _PostAccountReceivable(List<Models.AccountReceivable> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@DATA", _jsonstring);
                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_ACCOUNTRECEIVABLE", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

        public async Task<Response<Models.Result>> PostBankStatement(List<BankStatement> _list, string supplierVat)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostBankStatement(_list, supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        private async Task<Response<Result>> _PostBankStatement(List<BankStatement> _list, string supplierVat)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@DATA", _jsonstring);
                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);

                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_BANKSTATEMENT", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }


        public async Task<Response<List<Models.Document>>> GetPayment_Receipt(String supplierVat)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetPayment_Receipt(supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<List<Models.Document>>> _GetPayment_Receipt(String supplierVat)
        {
            Response<List<Models.Document>> _response = new Response<List<Models.Document>>();

            try
            {
                Util.Parameter _parameter = new Util.Parameter();
                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);

                Mapping _mapping = new Mapping();
                _mapping.AddItem("PaymentId", "IDPAYMENT");
                _mapping.AddItem("SupplierVat", "VSUPPLIERVAT");
                _mapping.AddItem("DealerVat", "VDEALERVAT");
                _mapping.AddItem("Date", "DDATE");
                _mapping.AddItem("Currency", "VCURRENCY");
                _mapping.AddItem("DocumentType", "VDOCUMENTTYPE");


                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_PAYMENT_RECEIPT", _parameter);
                _response.Data = _data.GetList<Models.Document>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

        public async Task<Response<List<Models.PaymentDetails>>> GetPayments_Consolidated(String supplierVat)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetPayments_Consolidated(supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<List<Models.PaymentDetails>>> _GetPayments_Consolidated(String supplierVat)
        {
            Response<List<Models.PaymentDetails>> _response = new Response<List<Models.PaymentDetails>>();

            try
            {
                Util.Parameter _parameter = new Util.Parameter();
                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);
                Mapping _mapping = new Mapping();
                _mapping.AddItem("Id", "ID");
                _mapping.AddItem("PaymentId", "IDPAYMENT");
                _mapping.AddItem("SupplierVat", "VSUPPLIERVAT");
                _mapping.AddItem("DocumentType", "VDOCUMENTTYPE");
                _mapping.AddItem("PaymentType", "VTYPE");
                _mapping.AddItem("Amount", "NAMOUNT");
                _mapping.AddItem("Date", "DDATE");
                _mapping.AddItem("Reference", "VREFERENCE");
                _mapping.AddItem("AmountRate", "NRATE");
                _mapping.AddItem("DateRate", "DDATERATE");
                _mapping.AddItem("Currency", "VCURRENCY");
                _mapping.AddItem("BankAccount", "VACCOUNTNUMBER");
                _mapping.AddItem("BankVat", "VVATBANK");
        

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_PAYMENTDETAILS_CONSOLIDATED", _parameter);
                _response.Data = _data.GetList<Models.PaymentDetails>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }


         public async Task<Response<List<Models.Document>>> GetRetention_Consolidated(String supplierVat)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetRetention_Consolidated(supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<List<Models.Document>>> _GetRetention_Consolidated(String supplierVat)
        {
            Response<List<Models.Document>> _response = new Response<List<Models.Document>>();

            try
            {
                Util.Parameter _parameter = new Util.Parameter();
                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);
            

                Mapping _mapping = new Mapping();
                _mapping.AddItem("PaymentId", "IDPAYMENT");
                _mapping.AddItem("SupplierVat", "VSUPPLIERVAT");
                _mapping.AddItem("DealerVat", "VDEALERVAT");
                _mapping.AddItem("Date", "DDATE");
                _mapping.AddItem("Currency", "VCURRENCY");
                _mapping.AddItem("DocumentType", "VDOCUMENTTYPE");
                _mapping.AddItem("Reference", "VREFERENCE");
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_RETENTION_CONSOLIDATED", _parameter);
                _response.Data = _data.GetList<Models.Document>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }


        public async Task<Response<List<Models.DocumentDetail>>> GetAccount_Consolidated(String supplierVat )
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetAccount_Consolidated(supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<List<Models.DocumentDetail>>> _GetAccount_Consolidated(String supplierVat)
        {
            Response<List<Models.DocumentDetail>> _response = new Response<List<Models.DocumentDetail>>();

            try
            {

                Util.Parameter _parameter = new Util.Parameter();
                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);


                Mapping _mapping = new Mapping();
                _mapping.AddItem("Id", "ID");
                _mapping.AddItem("PaymentId", "IDPAYMENT");
                _mapping.AddItem("Type", "VTYPE");
                _mapping.AddItem("Concept", "VCONCEPTCODE");
                _mapping.AddItem("Number", "VNUMBER");
                _mapping.AddItem("Reference", "VREFERENCE");
                _mapping.AddItem("Amount", "NPAIDAMOUNT");
                _mapping.AddItem("AmountRate", "NRATE");
                _mapping.AddItem("DateRate", "DDATERATE");
                _mapping.AddItem("Serie", "VSERIE");
                _mapping.AddItem("Control", "VCONTROL");
                _mapping.AddItem("Tax", "NTAX");
                _mapping.AddItem("WithholdTax", "NWITHHOLDTAX");
                _mapping.AddItem("Base", "NBASE");
                _mapping.AddItem("AmountTax", "NAMOUNTTAX");
                _mapping.AddItem("AmountNonTax", "NAMOUNTNONTAX");
                _mapping.AddItem("Sust", "NSUST");
                _mapping.AddItem("Secuence", "NSECUENCE");
                _mapping.AddItem("Date", "DDATE");

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_ACCOUNTRECEIVABLE_CONSOLIDATED", _parameter);
                _response.Data = _data.GetList<Models.DocumentDetail>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }


        public async Task<Response<List<Models.DocumentDetailRetention>>> GetAccount_Retention(String supplierVat)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetAccount_Retention(supplierVat);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<List<Models.DocumentDetailRetention>>> _GetAccount_Retention(String supplierVat)
        {
            Response<List<Models.DocumentDetailRetention>> _response = new Response<List<Models.DocumentDetailRetention>>();

            try
            {

                Util.Parameter _parameter = new Util.Parameter();
                _parameter.AddSqlParameter("@VSUPPLIERVAT", supplierVat);


                Mapping _mapping = new Mapping();
                _mapping.AddItem("Id", "ID");
                _mapping.AddItem("PaymentId", "IDPAYMENT");
                _mapping.AddItem("Type", "VTYPE");
                _mapping.AddItem("Concept", "VCONCEPTCODE");
                _mapping.AddItem("Number", "VNUMBER");
                _mapping.AddItem("Reference", "VREFERENCE");
                _mapping.AddItem("PaidAmount", "NPAIDAMOUNT");
                _mapping.AddItem("AmountRate", "NRATE");
                _mapping.AddItem("DateRate", "DDATERATE");
                _mapping.AddItem("Serie", "VSERIE");
                _mapping.AddItem("Control", "VCONTROL");
                _mapping.AddItem("Tax", "NTAX");
                _mapping.AddItem("WithholdTax", "NWITHHOLDTAX");
                _mapping.AddItem("Base", "NBASE");
                _mapping.AddItem("AmountTax", "NAMOUNTTAX");
                _mapping.AddItem("AmountNonTax", "NAMOUNTNONTAX");
                _mapping.AddItem("Sust", "NSUST");
                _mapping.AddItem("Secuence", "NSECUENCE");
                _mapping.AddItem("Date", "DDATE");



                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_ACCOUNTRECEIVABLE_RETENTION", _parameter);
                _response.Data = _data.GetList<Models.DocumentDetailRetention>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }

       


        public async Task<Response<Models.Result>> PostAsincPayment(List<Models.AsincPayment> _list)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _PostAsincPayment(_list);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<Models.Result>> _PostAsincPayment(List<Models.AsincPayment> _list)
        {
            Response<Models.Result> _response = new Response<Models.Result>();
            try
            {
                string _jsonstring = Util.Json.ConvertToJsonString(_list);
                Parameter _parameter = new Parameter();

                _parameter.AddSqlParameter("@DATA", _jsonstring);

                Mapping _mapping = new Mapping();
                _mapping.SetDefaultPostMapping();

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_POST_RECEIVEPAYMENTDETAILS_FIGO", _parameter);
                _response.Data = _data.GetItem<Models.Result>(_mapping, _table);
                _response.SetPostResponse();
            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }
            return _response;
        }
        #endregion

    }
}
