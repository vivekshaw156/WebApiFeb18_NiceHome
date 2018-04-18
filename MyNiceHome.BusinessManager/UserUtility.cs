using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using MyNiceHome.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.BusinessManager
{
    /// <summary>
    /// UserUtility Class
    /// </summary>
    public class UserUtility : IUserUtility
    {
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
        /// Connection Method
        /// </summary>
        /// <returns></returns>
        public bool GetConnection()
        {
            _repositoryUtility.GetNewConnection();
            return true;
        }

        /// <summary>
        /// Sender Method for Host to Add in Database
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool CreateNewHost(Host host)
        {
            _repositoryUtility.AddHost(host);
            return true;
        }

        /// <summary>
        /// Sender Method for Traveller to Add in Database
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public bool CreateNewTraveller(Traveller traveller)
        {
            _repositoryUtility.AddTraveller(traveller);
            return true;
        }
    }
}
