
using ClientApp.Repository;
using Lib_Models;
using Lib_Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class APIService: IAPIService
    {
        private String urlAPI = Program._api_url.api_url_inf.url;      
        //public tblcustomer dataLogin { get; set; }
        public int CodeReturn { get; set; }
        private API_Result result { get; set; }
        private Task<API_Result> resultAsync { get; set; }
        private RepositoryAPI RepApi { get; set; }
        public APIService() {
            RepApi = new RepositoryAPI();
        }
        public API_Result Auth(String phoneNumber)
        {
            try
            {
                String url = LinkAPI.auth;
                url = urlAPI + url;
                object param = new
                {
                    phonenum = phoneNumber
                };                
                resultAsync = RepApi.PostRequest(url, param);
                resultAsync.Wait();
                result = resultAsync.Result;
                return result;
            }
            catch
            {
                return null;
            }

        }
        public API_Result Regis(tblcustomer objinsert)
        {
            try
            {
                String url = LinkAPI.regis;
                url = urlAPI + url;              
                resultAsync = RepApi.PostRequest(url, objinsert);
                resultAsync.Wait();
                result = resultAsync.Result;
                return result;
            }
            catch
            {
                return null;
            }

        }

        public API_Result CreateTicket(tblticket objinsert)
        {
            try
            {
                String url = LinkAPI.createTick;
                url = urlAPI + url;
                resultAsync = RepApi.PostRequest(url, objinsert);
                resultAsync.Wait();
                result = resultAsync.Result;
                return result;
            }
            catch
            {
                return null;
            }
        }

        public API_Result Get_all_ticket_by_cus(int cusid)
        {
            try
            {
                String url = LinkAPI.getallTick+"/"+ cusid.ToString();
                url = urlAPI + url;
                resultAsync = RepApi.GetRequest(url);
                resultAsync.Wait();
                result = resultAsync.Result;
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
