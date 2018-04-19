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
            if (_repositoryUtility.CheckIfHostExists(host))
            {
                // todo throw an exception for already registered host
            }
            else
            {
                if (_repositoryUtility.AddHost(host))
                {
                    //todo send message for successful host addition in Database
                }
                else
                {
                    //todo throw exception for not adding in Database
                }
            }
            return true;
        }

        /// <summary>
        /// Sender Method for Adding Traveller Details
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public bool CreateNewTraveller(Traveller traveller)
        {
            if (_repositoryUtility.CheckIfTravellerExists(traveller))
            {
                // todo throw an exception for already registered traveller
            }
            else
            {
                if (_repositoryUtility.AddTraveller(traveller))
                {
                    //todo send message for successful traveller addition in Database
                }
                else
                {
                    //todo throw exception for not adding in Database
                }
            }
            return true;
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
