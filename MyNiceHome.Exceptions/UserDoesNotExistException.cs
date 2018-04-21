using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// UserDoesNotExist Exception Class
    /// </summary>
   public class UserDoesNotExistException:Exception
    {
        /// <summary>
        /// Constructor for UserDoesNotExistException
        /// </summary>
        /// <param name="message"></param>
        public UserDoesNotExistException(string message):base(message)
        {

        }

    }
}
