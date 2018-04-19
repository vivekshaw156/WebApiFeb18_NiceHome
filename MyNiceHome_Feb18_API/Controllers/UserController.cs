using MyNiceHome.BusinessManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        //[HttpPost]
        //public IHttpActionResult Create()
        //{
        //    return Ok();
        //}
    }
}