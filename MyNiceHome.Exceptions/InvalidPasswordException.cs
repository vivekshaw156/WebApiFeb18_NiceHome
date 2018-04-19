using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// InvalidPasswordException Class
    /// </summary>
    public class InvalidPasswordException:Exception
    {
        /// <summary>
        /// Constructor for InvalidPasswordException
        /// </summary>
        /// <param name="message"></param>
        public InvalidPasswordException(string message):base(message)
        {
               
        }
    }
}
