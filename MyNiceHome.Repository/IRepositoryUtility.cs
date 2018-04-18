using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    public interface IRepositoryUtility
    {
        // todo - pass object of user entity here
        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <returns></returns>
        bool Create();
    }
}
