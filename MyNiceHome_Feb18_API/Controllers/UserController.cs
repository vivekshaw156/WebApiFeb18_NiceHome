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
    /// <summary>
    /// UserController Class
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Readonly reference of IUserUtility Interface
        /// </summary>
        private readonly IUserUtility _userUtility;

        /// <summary>
        /// UserController Constructor
        /// </summary>
        /// <param name="userUtility"></param>
        public UserController(IUserUtility userUtility)
        {
            _userUtility = userUtility;
        }

        #region HttpGet Methods
        [HttpGet]
        public IHttpActionResult Index()
        {
            _userUtility.GetConnection();
            return Ok("Success");
        }
        #endregion

        #region HttpPost Methods
        [HttpPost]
        public IHttpActionResult CreateHost([FromBody] Host host)
        {
            bool result = _userUtility.CreateNewHost(host);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult CreateTraveller([FromBody] Traveller traveller)
        {
            bool result = _userUtility.CreateNewTraveller(traveller);
            return Ok();
        }
        #endregion
    }
}
