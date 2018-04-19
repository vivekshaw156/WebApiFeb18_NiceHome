using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// A class that mocks the RepositoryUtility for unit testing
    /// </summary>
    public class RepositoryMock : IRepositoryUtility
    {
        // todo - pass a host object to this method
        public bool AddHost(Host host)
        {
            throw new NotImplementedException();
        }

        // todo - pass a traveller object to this method
        public bool AddTraveller(Traveller traveller)
        {
            throw new NotImplementedException();
        }

        public bool GetNewConnection()
        {
            return true;
        }
        public bool CheckIfHostExists(Host host)
        {
            return true;
        }
        public bool CheckIfTravellerExists(Traveller traveller)
        {
            return true;
        }
    }
}
