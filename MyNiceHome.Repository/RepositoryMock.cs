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
            if (host.HostEmail.Equals(mockHost.HostEmail)&& host.HostPhone.Equals(mockHost.HostPhone))
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
            if (traveller.TravellerEmail.Equals(mockTraveller.TravellerEmail) && traveller.TravellerPhone.Equals(mockTraveller.TravellerPhone))
                return true;
            return false;
        }

        public string IsValidHostLogin(string email)
        {
            //todo check if host exists in database
            return "";
        }

        public bool IsValidTravellerLogin(string email, string password)
        {
            //todo check if traveller exists in database
            return true;
        }
    }
}
