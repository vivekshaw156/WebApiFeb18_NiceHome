using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNiceHome.Entities;

namespace MyNiceHome.BusinessManager.Interfaces
{
    /// <summary>
    /// IUserUtility Interface
    /// </summary>
    public interface IUserUtility
    {
        /// <summary>
        /// UnImplemented method for Sending Host details to Repository
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        bool CreateNewHost(Host host);

        /// <summary>
        /// UnImplemented method for Sending Traveller details to Repository
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        bool CreateNewTraveller(Traveller traveller);

        /// <summary>
        /// UnImplemented method for Creating New Connection 
        /// </summary>
        /// <returns></returns>
        bool GetConnection();
    }
}
