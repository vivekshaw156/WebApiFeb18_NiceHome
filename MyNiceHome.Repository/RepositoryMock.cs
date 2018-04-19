using MyNiceHome.Entities;
using System;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// A class that mocks the RepositoryUtility for unit testing
    /// </summary>
    public class RepositoryMock : IRepositoryUtility
    {
        public bool AddHost(Host host)
        {
            return true;
        }

        public bool AddTraveller(Traveller traveller)
        {
            return true;
        }

        public bool GetNewConnection()
        {
            throw new NotImplementedException();
        }
        public bool CheckIfHostExists(Host host)
        {
            Host mockHost = new Host
            {
                HostName = "Rajiv Thakur",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331556",
                HostPassword = "qwerty123"
            };
            if (host.Equals(mockHost))
                return true;
            return false;
        }
        public bool CheckIfTravellerExists(Traveller traveller)
        {
            Traveller mockTraveller = new Traveller
            {
                TravellerName = "Rajiv Thakur",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331556",
                TravellerPassword = "qwerty123"
            };
            if (traveller.Equals(mockTraveller))
                return true;
            return false;
        }
    }
}
