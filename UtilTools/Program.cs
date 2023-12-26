
using Lib_Models.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using UtilTools.Services;

namespace UtilTools
{
    class Program
    {
        public static API_url _api_url;
        static Thread process_data_lot_thread;
        private static APIService api_sv { get; set; }
        private static Random ranValue { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, đây là chương trình random số 0-9 của công ty SXKT.");
            _api_url = JsonConvert.DeserializeObject<API_url>(File.ReadAllText("API_URL.json"));
            api_sv = new APIService();
            ranValue = new Random();
            ParameterizedThreadStart pts = new ParameterizedThreadStart(process_data_lot);
            object objin = new object();
            process_data_lot_thread = new Thread(pts);
            process_data_lot_thread.Start(objin);
        }
        static void process_data_lot(object obj)
        {
            DateTime curdate = DateTime.Now;
            DateTime endDate = curdate.AddHours(1);
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, 0, 0);
            while (true)
            {
                try
                {
                    curdate = DateTime.Now;
                    if (curdate >= endDate)
                    {
                        endDate = curdate.AddHours(1);
                        endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, 0, 0);
                        int lotNum = ranValue.Next(0, 9);
                        API_Result rs = api_sv.create(new Lib_Models.tbllotdata() { lotnum = lotNum, session_ = curdate.Hour, datelot = curdate });
                        int insertState = JsonConvert.DeserializeObject<int>(rs.stringResult);
                        Console.WriteLine("Sổ xố: " + lotNum + (insertState == 1 ? " và lưu vào database thành công" : " và lưu vào database thất bại"));
                    }
                    //create
                    Console.WriteLine(curdate.ToString("dd-MM-yyyy HH:mm:ss"));
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }

        }

    }
}
