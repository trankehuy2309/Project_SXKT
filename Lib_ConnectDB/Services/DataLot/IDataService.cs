using System;
using System.Collections.Generic;
using System.Text;
using Lib_ConnectDB.Models;
using Lib_Models;

namespace Lib_ConnectDB.Services.DataLot
{
    interface IDataService
    {
        public int fn_create_datalot(tbllotdata dataInsert);        
        public void CloseConnect();
    }
}
