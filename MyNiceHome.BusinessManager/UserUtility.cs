using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNiceHome.Entities;

namespace MyNiceHome.BusinessManager
{
    /// <summary>
    /// UserUtility Class representing User Utilities
    /// </summary>
    public class UserUtility : IUserUtility
    {
        /// <summary>
        /// ReadOnly Reference for IRepositoryUtility Interface
        /// </summary>
        private readonly IRepositoryUtility _repositoryUtility;

        /// <summary>
        /// UserUtility Constructor
        /// </summary>
        /// <param name="repositoryUtility"></param>
        public UserUtility(IRepositoryUtility repositoryUtility)
        {
            _repositoryUtility = repositoryUtility;
        }

        /// <summary>
        /// Sender Method for Adding Host Details
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool CreateNewHost(Host host)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sender Method for Adding Traveller Details
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public bool CreateNewTraveller(Traveller traveller)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for Creating New Connection
        /// </summary>
        /// <returns></returns>
        public bool GetConnection()
        {
            _repositoryUtility.GetNewConnection();
            return true;
        }
    }
}
