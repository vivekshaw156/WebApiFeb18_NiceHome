using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace MyNiceHome_Feb18_API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserUtility _userUtility;
        
        public UserController(IUserUtility userUtility)
        {
            _userUtility = userUtility;
        }
        [HttpGet]
        public IHttpActionResult Index()
        {
            _userUtility.GetConnection();
            return Ok("Success");
        }

        [HttpPost]
        // todo - pass a host object to this action
        public IHttpActionResult CreateHost()
        {
            // todo - pass a host object to this method
            _userUtility.CreateNewHost();
            return Ok("Success");
        }

        [HttpPost]
        // todo - pass a traveller object to this action
        public IHttpActionResult CreateTraveller()
        {
            // todo - pass a host object to this method
            _userUtility.CreateNewTraveller();
            return Ok("Success");
        }

    }
}
