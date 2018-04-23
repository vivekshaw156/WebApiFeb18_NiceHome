using MyNiceHome.Entities;
using System;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// A class that mocks the RepositoryUtility for unit testing
    /// </summary>
    public class RepositoryMock : IRepositoryUtility
    {
        /// <summary>
        /// Dummy method for Adding Host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public Task<bool> AddHost(Host host)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Dummy method for Adding Host
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public Task<bool> AddTraveller(Traveller traveller)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Dummy Connection method
        /// </summary>
        /// <returns></returns>
        public bool GetNewConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dummy Host Checking method 
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public Task<bool> CheckIfHostExists(Host host)
        {
            Host mockHost = new Host
            {
                HostName = "Rajiv Thakur",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331556",
                HostPassword = "qwerty123"
            };
            if (host.HostEmail.Equals(mockHost.HostEmail)&& host.HostPhone.Equals(mockHost.HostPhone))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        /// <summary>
        /// Dummy Traveller checking method
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public Task<bool> CheckIfTravellerExists(Traveller traveller)
        {
            Traveller mockTraveller = new Traveller
            {
                TravellerName = "Rajiv Thakur",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331556",
                TravellerPassword = "qwerty123"
            };
            if (traveller.TravellerEmail.Equals(mockTraveller.TravellerEmail) && traveller.TravellerPhone.Equals(mockTraveller.TravellerPhone))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        /// <summary>
        /// Dummy method for Valid Host
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<string> IsValidHostLogin(string email)
        {
            // mock password hash for password=password123
            if (email == "something@domainName.com")
                return Task.FromResult("$2a$10$DRKlSiSQgoQozgysjguJou5OoMmyhFxNW5FzvuhYOs.bhxPEVUlbq");
            else
                return null;
        }

        /// <summary>
        /// Dummy method for Valid Traveller
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<string> IsValidTravellerLogin(string email)
        {
            // mock password hash for password=password123
            if (email == "something@domainName.com")
                return Task.FromResult("$2a$10$DRKlSiSQgoQozgysjguJou5OoMmyhFxNW5FzvuhYOs.bhxPEVUlbq");
            else
                return null;
        }
    }
}
