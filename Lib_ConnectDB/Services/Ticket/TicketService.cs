using Lib_ConnectDB.Models;
using Lib_ConnectDB.Repository;
using Lib_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib_ConnectDB.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private Repository_DB Rep { get; set; }
        public TicketService() {
            Rep = new Repository_DB();
        }
        public List<tblticket> fn_get_all_ticket_by_cusid(int cusid) {
            try
            {
                List<tblticket> listTick= Rep.ExecuteStoreProceduce<tblticket>("sp_get_all_ticket_by_cusid", new Dictionary<string, string>() {
                    { "cusid_",cusid.ToString()}
                }).ToList();
                try {
                    String codeUpdate = "";
                    foreach (var item in listTick)
                    {
                        if (item.ismatch == -1 && item.ismatch != item.ischeck)
                        {
                            codeUpdate += "update tblticket set ismatch=" + item.ischeck.ToString() + " where tickid=" + item.tickid.ToString() + ";";
                            item.ismatch = item.ischeck;
                        }
                    }
                    if (!String.IsNullOrEmpty(codeUpdate)) {
                        Rep.ExecuteSqlQuery_Basic(codeUpdate);
                    }
                }
                catch { }
             
                return listTick;
            }
            catch {
                return null;
            }
        }
        public int fn_create_ticket(tblticket ticketInsert) {
            try
            {
                return Rep.ExecuteStoreProceduce<int>("sp_create_tblticket", new Dictionary<string, string>() {
                    {"lot_num_",ticketInsert.lot_num.ToString() },
                    {"cusid_",ticketInsert.cusid.ToString() },
                    {"_session_",ticketInsert.session_.ToString()},
                    {"datelot_",ticketInsert.datelot.ToString("yyyy-MM-dd")}
                }).FirstOrDefault();
            }
            catch {
                return 0;
            }
        }
        public void CloseConnect()
        {
            Rep.Dispose();
        }
    }
}
