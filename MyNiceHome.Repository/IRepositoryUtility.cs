﻿using MyNiceHome.Entities;
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
        bool AddHost(Host host);

        /// <summary>
        /// UnImplemented method for adding Traveller details in Database
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        bool AddTraveller(Traveller traveller);

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
        bool CheckIfHostExists(Host host);

        /// <summary>
        /// UnImplemented Method for Checking already registered Traveller
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        bool CheckIfTravellerExists(Traveller traveller);
    }
}
