using System;
using System.Collections.Generic;
using System.Text;
using Lib_ConnectDB.Models;
using Lib_Models;

namespace Lib_ConnectDB.Services.Customer
{
    interface ICustomerService
    {
        public List<tblcustomer> fn_get_allCus();
        public tblcustomer fn_get_Cus_by_phone(String phoneNumber);
        public int fn_regis_customer(tblcustomer cusInsert);
        public void CloseConnect();
    }
}
