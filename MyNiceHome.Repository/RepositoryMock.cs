using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// A class that mocks the RepositoryUtility for unit testing
    /// </summary>
    public class RepositoryMock : IRepositoryUtility
    {
        /// <summary>
        /// Mocked Connection Method
        /// </summary>
        /// <returns></returns>
        public bool GetNewConnection()
        {
            return true;
        }

        /// <summary>
        /// Mocked AddHost Method
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool AddHost(Host host)
        {
            return true;
        }

        /// <summary>
        /// Mocked AddTraveller Method
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public bool AddTraveller(Traveller traveller)
        {
            return true;
        }
    }
}
