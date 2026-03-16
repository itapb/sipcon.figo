
using System.Data;
using Models;
using Util;

namespace Data
{
    public class dVehicle
    {

        private readonly SemaphoreSlim _semaphore;
        public dVehicle()
        {

            Util.Setting.GetSettings(true);
            _semaphore = new SemaphoreSlim(100, 150);
        }


        public async Task<Response<Models.Vehicle>> GetVehicleBy(String vat, String plate)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetVehicleBy(vat,plate);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<Models.Vehicle>> _GetVehicleBy(String vat, String plate)
        {
            Response<Models.Vehicle> _response = new Response<Models.Vehicle>();

            try
            {
               
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@VVAT", vat);
                _parameter.AddSqlParameter("@VPLATE", plate);

                Mapping _mapping = new Mapping();
                _mapping.AddItem("Vin", "VVIN");
                _mapping.AddItem("EngineSerial", "VENGINESERIAL");
                _mapping.AddItem("Plate", "VPLATE");
                _mapping.AddItem("Year", "IYEAR");
                _mapping.AddItem("ModelName", "VMODEL");
                _mapping.AddItem("ColorName", "VCOLOR");
                _mapping.AddItem("DealerName", "VDEALER");
                _mapping.AddItem("ActivationDate", "DACTIVATIONDATE");
                _mapping.AddItem("LockDate", "DLOCKDATE");
                _mapping.AddItem("ExpirationDate", "DEXPIRATIONDATE");
                _mapping.AddItem("PolicyEstatus", "ESTATUSNAME");


                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_VEHICLE_APPCHANGAN", _parameter);
                _response.Data = _data.GetItem<Models.Vehicle>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }

            return _response;

        }



   


        public async Task<Response<List<Models.Service>>> GetServiceRecord(String plate)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetServiceRecord(plate);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<Response<List<Models.Service>>> _GetServiceRecord(String plate)
        {

            Response<List<Models.Service>> _response = new Response<List<Models.Service>>();

            try
            {

                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@VPLATE", plate);

                Mapping _mapping = new Mapping();
                _mapping.AddItem("ServiceId", "IDREPORT");
                _mapping.AddItem("ServiceTypeId", "IDSERVICETYPE");
                _mapping.AddItem("ServiceTypeName", "VSERVICETYPE");
                _mapping.AddItem("ReportTypeName", "VREPORTTYPE");
                _mapping.AddItem("OrderNumber", "VSERVICENUMBER");
                _mapping.AddItem("Km", "IKM");
                _mapping.AddItem("ServiceDate", "DCREATED");
                _mapping.AddItem("InvoiceAmount", "NINVOICEAMOUNT");
                _mapping.AddItem("DealerServiceName", "DEALER");
                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_SERVICEVEHICLE_APPCHANGAN", _parameter);
                _response.Data = _data.GetList<Models.Service>(_mapping, _table);
                _response.SetGetResponse(_table);

            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }

            return _response;

        }

        
        
        public async Task<Response<Models.Contact>> GetCustomerBy(String vat, String plate)
        {
            await _semaphore.WaitAsync(Util.Setting.TimeOut);
            try
            {
                return await _GetCustomerBy(vat,plate);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        private async Task<Response<Models.Contact>> _GetCustomerBy(String vat, String plate)
        {
            Response<Models.Contact> _response = new Response<Models.Contact>();

            try
            {
                Parameter _parameter = new Parameter();
                _parameter.AddSqlParameter("@VVAT", vat);
                _parameter.AddSqlParameter("@VPLATE", plate);


                Mapping _mapping = new Mapping();

                _mapping.AddItem("Vat", "VVAT");
                _mapping.AddItem("CustomerName", "VCUSTOMERNAME");
                _mapping.AddItem("Address", "VADDRESS");
                _mapping.AddItem("Phone1", "VPHONE1");
                _mapping.AddItem("Phone2", "VPHONE2");
                _mapping.AddItem("Email", "VEMAIL");
                _mapping.AddItem("CityName", "VCITY");
                _mapping.AddItem("State", "VSTATE");
                _mapping.AddItem("Male", "BMALE");
                _mapping.AddItem("Birthday", "DBIRTHDATE");

                Util.Data _data = Util.Data.GetInstance();
                DataTable _table = await _data.GetDataTable("USP_GET_VEHICLE_APPCHANGAN", _parameter);
                _response.Data = _data.GetItem<Models.Contact>(_mapping, _table);
                _response.SetGetResponse(_table);



            }
            catch (Exception ex)
            {
                _response.SetError(ex);
            }

            return _response;

        }



    }
}
