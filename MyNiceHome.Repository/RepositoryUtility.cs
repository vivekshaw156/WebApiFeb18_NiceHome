using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    public class RepositoryUtility:IRepositoryUtility
    {
        MyNiceHomeContext context = new MyNiceHomeContext();
        
        // todo - pass a host object to this method
        public bool AddHost()
        {
            throw new NotImplementedException();
        }

        // todo - pass a traveller object to this method
        public bool AddTraveller()
        {
            throw new NotImplementedException();
        }

        public bool GetNewConnection()
        {
            context.HostDetails.ToList();
            return true;
        }
    }
}
