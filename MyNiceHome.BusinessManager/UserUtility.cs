using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.BusinessManager
{
    public class UserUtility : IUserUtility
    {
        private readonly IRepositoryUtility _repositoryUtility;
        public UserUtility(IRepositoryUtility repositoryUtility)
        {
            _repositoryUtility = repositoryUtility;
        }
        
        // todo - pass a host object to this method
        public bool CreateNewHost()
        {
            throw new NotImplementedException();
        }

        // todo - pass a host object to this method
        public bool CreateNewTraveller()
        {
            throw new NotImplementedException();
        }

        public bool GetConnection()
        {
            _repositoryUtility.GetNewConnection();
            return true;
        }
    }
}
