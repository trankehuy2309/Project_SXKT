
using Lib_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilTools.Repository
{
    public interface IRepositoryAPI
    {
        Task<API_Result> PostRequest(string url, object input);
        Task<API_Result> GetRequest(string url);
        API_Result GetRequest_Param(string url, object input);
    }
}
