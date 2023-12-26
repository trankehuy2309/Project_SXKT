using Lib_ConnectDB.Models;
using Lib_ConnectDB.Repository;
using Lib_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib_ConnectDB.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private Repository_DB Rep { get; set; }
        public CustomerService() {
            Rep = new Repository_DB();
        }
        public List<tblcustomer> fn_get_allCus()
        {
            try {
                return Rep.ExecuteStoreProceduce<tblcustomer>("sp_get_all_customer").ToList();
            }
            catch {
                return null;
            }
        }
        public int fn_regis_customer(tblcustomer cusInsert) {
            try {
                return Rep.ExecuteStoreProceduce<int>("sp_create_customer", new Dictionary<string, string>() {
                    { "_name_",cusInsert.name_},
                    { "phonenumber_",cusInsert.phonenumber },
                    { "_address_",cusInsert.address_},
                    { "dateofbirth_",cusInsert.dateofbirth.ToString("yyyy-MM-dd") }
                }               
                ).FirstOrDefault();
            }
            catch {
                return 0;
            }
        }
        public tblcustomer fn_get_Cus_by_phone(String phoneNumber)
        {
            try
            {
                return Rep.ExecuteStoreProceduce<tblcustomer>("sp_get_customer_by_phone", new Dictionary<string, string>() {
                   {"phone_",phoneNumber.Trim() }
                }).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void CloseConnect()
        {
            Rep.Dispose();
        }
    }
}
