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
        public bool Create()
        {
            // todo - object validations
            throw new NotImplementedException();
        }
        public bool GetNewConnection()
        {
            return true;
        }
    }
}
