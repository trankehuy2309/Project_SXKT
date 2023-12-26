
using Lib_Models;
using Lib_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public interface IAPIService
    {
        API_Result Auth(String phoneNumber);
        API_Result Regis(tblcustomer objinsert);
        API_Result CreateTicket(tblticket objinsert);
        API_Result Get_all_ticket_by_cus(int cusid);
    }
}
