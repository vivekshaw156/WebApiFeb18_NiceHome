using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyNiceHome_Feb18_API.Controllers
{
    public class PropertyListController : ApiController
    {
        private readonly IPropertyUtility _propertyUtility;
        public PropertyListController(IPropertyUtility propertyUtility)
        {
            _propertyUtility = propertyUtility;
        }
        [HttpGet]
        public IHttpActionResult SearchResult()
        {
            SearchData searchData = new SearchData();
            searchData.NoOfPeople = 10;
            searchData.Place = "Bengaluru";
            searchData.ToDateInString =  "2019-04-27";
            searchData.FromDateInString = "2018-04-27";
            List<Property> propertyList = new List<Property>();
            propertyList = _propertyUtility.GetPropertyList(searchData.Place,searchData.FromDateInString,searchData.ToDateInString,searchData.NoOfPeople);
            return Ok(propertyList);
        }
    }
}
