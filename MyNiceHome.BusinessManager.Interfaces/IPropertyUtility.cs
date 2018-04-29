using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.BusinessManager.Interfaces
{
    public interface IPropertyUtility
    {
        List<Property> GetPropertyList(string place, string fromDate, string toDate, int people);
    }
}
