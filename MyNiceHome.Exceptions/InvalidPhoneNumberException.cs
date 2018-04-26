using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// InvalidPhoneNumberException Class
    /// </summary>
    public class InvalidPhoneNumberException:Exception
    {
        /// <summary>
        /// Constructor for InvalidPhoneNumberException
        /// </summary>
        /// <param name="message"></param>
        public InvalidPhoneNumberException(string message):base(message)
        {

        }
    }
}
