using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// RepositoryUtility Class
    /// </summary>
    public class RepositoryUtility:IRepositoryUtility
    {
        /// <summary>
        /// Reference of MyNiceHomeContext
        /// </summary>
        MyNiceHomeContext context;

        /// <summary>
        /// Constructor for RepositoryUtility
        /// </summary>
        public RepositoryUtility()
        {
            context = new MyNiceHomeContext();
        }

        /// <summary>
        /// Creating a New Connection
        /// </summary>
        /// <returns></returns>
        public bool GetNewConnection()
        {
            context.HostDetails.ToList();
            return true;
        }

        /// <summary>
        /// Adding a Host Details in Database
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool AddHost(Host host)
        {
            context.HostDetails.Add(host);
            return (context.SaveChanges() > 0) ? true : false;
        }

        /// <summary>
        /// Adding a Traveller details in Database 
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public bool AddTraveller(Traveller traveller)
        {
            context.TravellerDetails.Add(traveller);
            return (context.SaveChanges() > 0) ? true : false;
        }

    }
}
