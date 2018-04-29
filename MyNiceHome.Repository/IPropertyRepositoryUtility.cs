using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    public interface IPropertyRepositoryUtility
    {
        List<Property> GetPropertyDetails(string place, string fromDate, string toDate, int people);

    }
}
