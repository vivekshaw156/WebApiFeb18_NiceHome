using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    /// <summary>
    /// Generic Class for OperationStatus
    /// </summary>
    public class OperationResult
    {
        #region Properties of OperationResult Class
        public HttpStatusCode StatusCode { get; set; }
        public String  Message { get; set; }
        public bool Status { get; set; }
        #endregion
    }
}
