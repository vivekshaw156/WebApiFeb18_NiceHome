using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// DuplicateEntryException Class
    /// </summary>
    public class DuplicateEntryException:Exception
    {
        /// <summary>
        /// Constructor for DuplicateEntryException
        /// </summary>
        /// <param name="message"></param>
        public DuplicateEntryException(string message):base(message)
        {

        }
    }
}
