using Lib_ConnectDB.Models;
using Lib_ConnectDB.Repository;
using Lib_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib_ConnectDB.Services.DataLot
{
    public class DataService : IDataService
    {
        private Repository_DB Rep { get; set; }
        public DataService() {
            Rep = new Repository_DB();
        }
        
        public int fn_create_datalot(tbllotdata dataInsert) {
            try
            {
                return Rep.ExecuteStoreProceduce<int>("sp_insert_tbllotdata", new Dictionary<string, string>() {
                    {"lotnum_",dataInsert.lotnum.ToString() },
                    {"_session_",dataInsert.session_.ToString() },
                    {"datelot_",dataInsert.datelot.ToString("yyyy-MM-dd")}
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
