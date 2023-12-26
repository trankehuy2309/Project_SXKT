using Lib_ConnectDB.Services.Customer;
using Lib_ConnectDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_SXKT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lib_Models;

namespace Project_SXKT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private CustomerService cusSv;
        public HomeController() {
            cusSv = new CustomerService();
        }

        [HttpGet]
        public JsonResult Index()
        {
            try
            {
                List<tblcustomer> listCus= cusSv.fn_get_allCus();
                cusSv.CloseConnect();
                return new JsonResult("Welcome to SXKT system");
            }
            catch
            {
                return new JsonResult(false);

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
