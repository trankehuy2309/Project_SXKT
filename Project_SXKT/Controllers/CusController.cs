using Lib_ConnectDB.Services.Customer;
using Lib_Models;
using Microsoft.AspNetCore.Mvc;
using Project_SXKT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SXKT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CusController : Controller
    {
        private CustomerService cusSv;
        public CusController()
        {
            cusSv = new CustomerService();
        }
        [HttpPost("Auth")]
        public async Task<ActionResult> Auth(Auth authObj)
        {
            try
            {
                return new JsonResult(cusSv.fn_get_Cus_by_phone(authObj.phonenum));
            }
            catch
            {
                return BadRequest();
            }
        }
        //
        [HttpPost("Regis")]
        public async Task<ActionResult> Regis(tblcustomer cusinsert)
        {
            try
            {
                return new JsonResult(cusSv.fn_regis_customer(cusinsert));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
