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
        public Task<bool> AddHost(Host host)
        {
            return Task.FromResult(true);
        }

        public Task<bool> AddTraveller(Traveller traveller)
        {
            return Task.FromResult(true);
        }

        public bool GetNewConnection()
        {
            throw new NotImplementedException();
        }

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

        public Task<string> IsValidHostLogin(string email)
        {
            //todo check if host exists in database
            return Task.FromResult("");
        }

        public Task<string> IsValidTravellerLogin(string email)
        {
            //todo check if traveller exists in database
            return Task.FromResult("");
        }
    }
}
