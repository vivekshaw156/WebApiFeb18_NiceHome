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
        public bool Create()
        {
            throw new NotImplementedException();
        }
    }
}
