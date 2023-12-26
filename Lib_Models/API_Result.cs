using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Models
{
    public class API_Result
    {
        public API_Result(int codeResult_, String stringResult_)
        {
            codeResult = codeResult_;
            stringResult = stringResult_;
        }
        public API_Result()
        {

        }
        public int codeResult { get; set; }
        public String stringResult { get; set; }
    }
}
