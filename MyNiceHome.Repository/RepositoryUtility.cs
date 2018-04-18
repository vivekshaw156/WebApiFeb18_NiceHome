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

        public bool Create()
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
