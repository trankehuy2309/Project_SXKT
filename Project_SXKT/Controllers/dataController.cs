using Lib_ConnectDB.Services.DataLot;
using Lib_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SXKT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class dataController : Controller
    {
        private DataService datasv { get; set; }
        public dataController()
        {
            datasv = new DataService();
        }
        [HttpPost("create")]
        public async Task<ActionResult> create(tbllotdata dataobj)
        {
            try
            {
                return new JsonResult(datasv.fn_create_datalot(dataobj));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
