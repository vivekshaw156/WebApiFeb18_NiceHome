using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// InvalidCityNameException Class
    /// </summary>
    public class InvalidCityException:Exception
    {
        /// <summary>
        /// Constructor for InvalidCityNameException
        /// </summary>
        /// <param name="message"></param>
        public InvalidCityException(string message):base(message)
        {

        }
    }
}
