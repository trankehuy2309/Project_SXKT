
using UtilTools.Repository;
using Lib_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_Models.Models;

namespace UtilTools.Services
{
    public class APIService: IAPIService
    {
        private String urlAPI = Program._api_url.api_url_inf.url;      
        
        public int CodeReturn { get; set; }
        private API_Result result { get; set; }
        private Task<API_Result> resultAsync { get; set; }
        private RepositoryAPI RepApi { get; set; }
        public APIService() {
            RepApi = new RepositoryAPI();
        }
        public API_Result create(tbllotdata dataobj)
        {
            try
            {
                String url = LinkAPI.createdata;
                url = urlAPI + url;                            
                resultAsync = RepApi.PostRequest(url, dataobj);
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
