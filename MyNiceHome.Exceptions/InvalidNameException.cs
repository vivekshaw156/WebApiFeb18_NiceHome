using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// InvalidNameException Class
    /// </summary>
    public class InvalidNameException:Exception
    {
        /// <summary>
        /// Constructor for InvalidNameException
        /// </summary>
        /// <param name="message"></param>
        public InvalidNameException(string message):base(message)
        {
                
        }

    }
}
