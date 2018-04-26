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
        /// Reference for MyNiceHomeContext Class
        /// </summary>
        MyNiceHomeContext context;

        /// <summary>
        /// Constructor of RepositoryUtility Class
        /// </summary>
        public RepositoryUtility()
        {
            context = new MyNiceHomeContext();
        }

        /// <summary>
        /// Adding Host Details in Database
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public async Task<bool> AddHost(Host host)
        {
            context.HostDetails.Add(host);
            return (await context.SaveChangesAsync() > 0) ? true : false;
        }

        /// <summary>
        /// Adding Traveller Details in Database
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public async Task<bool> AddTraveller(Traveller traveller)
        {
            context.TravellerDetails.Add(traveller);
            return (await context.SaveChangesAsync() > 0) ? true : false;
        }

        /// <summary>
        /// Creating the Database
        /// </summary>
        /// <returns></returns>
        public bool GetNewConnection()
        {
            context.HostDetails.ToList();
            return true;
        }

        /// <summary>
        /// Method to check already Registered host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfHostExists(Host host)
        {
            var queryOne = await Task.FromResult(from user in context.HostDetails
                            where user.HostEmail == host.HostEmail select user);
            if (queryOne.ToList().Count == 1)
            {
                return true;
            }
            else
            {
                var queryTwo = await Task.FromResult(from user in context.HostDetails
                                where user.HostPhone == host.HostPhone
                                select user);
                if(queryTwo.ToList().Count == 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method to check already Registered Traveller
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfTravellerExists(Traveller traveller)
        {
            var queryOne = await Task.FromResult(from user in context.TravellerDetails
                            where user.TravellerEmail == traveller.TravellerEmail
                            select user);
            if (queryOne.ToList().Count == 1)
            {
                return true;
            }
            else
            {
                var queryTwo = await Task.FromResult(from user in context.TravellerDetails
                                where user.TravellerPhone == traveller.TravellerPhone
                                select user);
                if (queryTwo.ToList().Count == 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check for Valid Host Login in Database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> IsValidHostLogin(string email)
        {
            var query =  await Task.FromResult(context.HostDetails
                        .Where(host => host.HostEmail == email)
                        .Select(host=> host.HostPassword));
                        
            return
                query.FirstOrDefault();
        }

        /// <summary>
        /// Check for valid Traveller Login in Database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> IsValidTravellerLogin(string email)
        {
            var query = await Task.FromResult(from traveller in context.TravellerDetails
                        where traveller.TravellerEmail == email
                        select traveller.TravellerPassword);
            return
                query.FirstOrDefault();
        }
    }
}
