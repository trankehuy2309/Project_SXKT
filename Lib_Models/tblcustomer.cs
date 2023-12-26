using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models
{
    public class tblcustomer
    {
        public int cusid { get; set; }
        public String name_ { get; set; }
        public String phonenumber { get; set; }
        public String address_ { get; set; }
        public DateTime lastlog { get; set; }
        public DateTime dateofbirth { get; set; }
    }
}
