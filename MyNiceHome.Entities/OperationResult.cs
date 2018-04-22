using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class OperationResult
    {
        public HttpStatusCode StatusCode { get; set; }
        //public int StatusCode { get; set; }
        public String  Message { get; set; }
        public bool Status { get; set; }
    }
}
