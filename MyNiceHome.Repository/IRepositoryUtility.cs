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
        /// UnImplemented method for adding Host details in Database
        /// </summary>
        /// <returns></returns>
        Task<bool> AddHost(Host host);

        /// <summary>
        /// UnImplemented method for adding Traveller details in Database
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        Task<bool> AddTraveller(Traveller traveller);

        /// <summary>
        /// UnImplemented method for Creating Database
        /// </summary>
        /// <returns></returns>
        bool GetNewConnection();

        /// <summary>
        /// UnImplemented method for Checking already registered Host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        Task<bool> CheckIfHostExists(Host host);

        /// <summary>
        /// UnImplemented Method for Checking already registered Traveller
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        Task<bool> CheckIfTravellerExists(Traveller traveller);

        /// <summary>
        /// UnImplemented Method for Checking valid host in Database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> IsValidHostLogin(string email);

        string IsValidHost(string email);

        string IsValidTraveller(string email);

        bool CreateNewHostPassword(string newPassword, string hostId);

        bool CreateNewTravellerPassword(string newPassword, string travellerId);



        /// <summary>
        /// UnImplemented Method for Checking valid traveller in Database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> IsValidTravellerLogin(string email);
    }
}
