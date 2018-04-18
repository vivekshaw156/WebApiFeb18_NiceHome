using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.BusinessManager.Interfaces
{
    public interface IUserUtility
    {
        // todo - pass a new user entity object into create
        bool Create();
    }
}
