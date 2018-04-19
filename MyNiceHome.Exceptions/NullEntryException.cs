using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    /// <summary>
    /// NullEntryException Class
    /// </summary>
    public class NullEntryException:Exception
    {
        /// <summary>
        /// Constructor for NullEntryException
        /// </summary>
        /// <param name="message"></param>
        public NullEntryException(string message):base(message)
        {

        }
    }
}
