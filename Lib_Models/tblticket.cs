using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models
{
    public class tblticket
    {
        public int tickid { get; set; }
        public int lot_num { get; set; }
        public int cusid { get; set; }
        public int session_ { get; set; }
        public DateTime datelot { get; set; }
        public int ismatch { get; set; }
        public int ischeck { get; set; }
        public DateTime lastedit { get; set; }
    }
}
