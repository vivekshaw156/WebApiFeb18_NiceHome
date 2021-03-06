﻿using System;
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
        Task<bool> CreateNewHost(Host host);

        /// <summary>
        /// UnImplemented method for Sending Traveller details to Repository
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        Task<bool> CreateNewTraveller(Traveller traveller);

        /// <summary>
        /// UnImplemented method for Creating New Connection 
        /// </summary>
        /// <returns></returns>
        bool GetConnection();

        /// <summary>
        /// UnImplemented Method for Checking Business Logic for Host
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> HostLoginAccess(string email, string password);

  

        /// <summary>
        ///  UnImplemented Method for Checking Business Logic for Traveller
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> TravellerLoginAccess(string email, string password);

        bool ResetHostPassword(string email);

        bool ResetNewHostPassword(string newPassword, string HostId);

        bool ResetTravellerPassword(string email);

        bool ResetNewTravellerPassword(string newPassword, string TravellerId);

    }
}
