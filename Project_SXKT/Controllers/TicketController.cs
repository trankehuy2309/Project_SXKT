using Lib_ConnectDB.Services.Ticket;
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
    public class TicketController : Controller
    {
        private TicketService ticksv { get; set; }
        public TicketController() {
            ticksv = new TicketService();
        }
        [HttpPost("create")]
        public async Task<ActionResult> create(tblticket tickobj)
        {
            try
            {
                return new JsonResult(ticksv.fn_create_ticket(tickobj));
            }
            catch
            {
                return BadRequest();
            }
        }
        //fn_get_all_ticket_by_cusid
        [HttpGet("all/{cusid}")]
        public async Task<ActionResult> gettickbycusid(int cusid)
        {
            try
            {
                return new JsonResult(ticksv.fn_get_all_ticket_by_cusid(cusid));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
