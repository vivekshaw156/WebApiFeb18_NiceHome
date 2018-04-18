using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNiceHome.Entities;

namespace MyNiceHome.BusinessManager.Interfaces
{
    public interface IUserUtility
    {
        // todo - pass a new user entity object into create
        bool CreateNewHost(Host host);
        bool CreateNewTraveller(Traveller traveller);
        bool GetConnection();
    }
}
