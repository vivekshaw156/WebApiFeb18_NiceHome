using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.BusinessManager.Interfaces
{
    /// <summary>
    /// IUserUtility Interface
    /// </summary>
    public interface IUserUtility
    {
        /// <summary>
        /// Unimplemented Method for Sending Host data to database
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        bool CreateNewHost(Host host);

        /// <summary>
        /// Unimplemented Method for Sending Traveller data to database
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        bool CreateNewTraveller(Traveller traveller);

        /// <summary>
        /// Unimplemented Method for Getting Connection
        /// </summary>
        /// <returns></returns>
        bool GetConnection();
    }
}
