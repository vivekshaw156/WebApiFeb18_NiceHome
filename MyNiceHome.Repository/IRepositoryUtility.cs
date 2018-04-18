using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// IRepositoryUtility Interface
    /// </summary>
    public interface IRepositoryUtility
    {
        /// <summary>
        /// UnImplemented Method for Adding Host data in Database
        /// </summary>
        /// <returns></returns>
        bool AddHost(Host host);

        /// <summary>
        /// UnImplemented Method for Adding Traveller data in Database
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        bool AddTraveller(Traveller traveller);

        /// <summary>
        /// UnImplemented Method for Creating Connection
        /// </summary>
        /// <returns></returns>
        bool GetNewConnection();
    }
}
