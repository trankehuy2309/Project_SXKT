
using Lib_Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UtilTools.Repository
{
    public class RepositoryAPI: IRepositoryAPI
    {
        public async Task<API_Result> GetRequest(string url)
        {
            API_Result objectReturn = new API_Result(500, "");
 
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
   
                // httpWebRequest.GetRequestStream();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    objectReturn.codeResult = (int)(httpResponse.StatusCode);
                    objectReturn.stringResult = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                httpResponse.Close();
                return objectReturn;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public API_Result GetRequest_Param(string url, object input)
        {
            API_Result objectReturn = new API_Result(500, "");
           
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";      
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json1 = JsonConvert.SerializeObject(input);
                    streamWriter.Write(json1);
                    streamWriter.Close();
                }

                // Console.WriteLine("\n" + DateTime.Now + "\t" + JsonConvert.SerializeObject(input));
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Console.WriteLine(httpResponse.StatusCode);
                    objectReturn.codeResult = (int)httpResponse.StatusCode;
                    objectReturn.stringResult = streamReader.ReadToEnd();
                    //Console.WriteLine(result);
                    streamReader.Close();
                }
                httpResponse.Close();
                return objectReturn;

            }
            catch
            {
                return null;
            }


        }
        public async Task<API_Result> PostRequest(string url, object input)
        {
            API_Result objectReturn = new API_Result(500, "");
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
        
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json1 = JsonConvert.SerializeObject(input);
                    streamWriter.Write(json1);
                    streamWriter.Close();
                }

                // Console.WriteLine("\n" + DateTime.Now + "\t" + JsonConvert.SerializeObject(input));
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Console.WriteLine(httpResponse.StatusCode);
                    objectReturn.codeResult = (int)httpResponse.StatusCode;
                    objectReturn.stringResult = streamReader.ReadToEnd();
                    //Console.WriteLine(result);
                    streamReader.Close();
                }
                httpResponse.Close();
                return objectReturn;

            }
            catch
            {
                return null;
            }


        }
    }
}
