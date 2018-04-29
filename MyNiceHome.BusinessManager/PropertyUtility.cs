using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using MyNiceHome.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.BusinessManager
{
    public class PropertyUtility : IPropertyUtility
    {
        private readonly IPropertyRepositoryUtility _propertyRepositoryUtility;
        public PropertyUtility(IPropertyRepositoryUtility propertyRepositoryUtility)
        {
            _propertyRepositoryUtility = propertyRepositoryUtility;
        }
        public List<Property> GetPropertyList(string place, string fromDate, string toDate, int people)
        {
            List<Property> propertyList = new List<Property>();
            if (place == null || fromDate == null || toDate == null || people == 0)
            {
                // todo throw an exception
            }
            else
            {
                propertyList = _propertyRepositoryUtility.GetPropertyDetails(place, fromDate, toDate, people);
            }
            return propertyList;
        }
    }
}
