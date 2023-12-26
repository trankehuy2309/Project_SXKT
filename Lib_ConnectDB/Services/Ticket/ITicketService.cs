using System;
using System.Collections.Generic;
using System.Text;
using Lib_ConnectDB.Models;
using Lib_Models;

namespace Lib_ConnectDB.Services.Ticket
{
    interface ITicketService
    {
        public int fn_create_ticket(tblticket ticketInsert);
        public List<tblticket> fn_get_all_ticket_by_cusid(int cusid);
        public void CloseConnect();
    }
}
