using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using System;
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
        /// ReadOnly Reference for IUserUtility Interface
        /// </summary>
        private readonly IUserUtility _userUtility;
        
        /// <summary>
        /// Constructor for UserController Class
        /// </summary>
        /// <param name="userUtility"></param>
        public UserController(IUserUtility userUtility)
        {
            _userUtility = userUtility;
        }

        #region HttpGet Methods
        /// <summary>
        /// Calling this endpoint will create a new local database if no databaase exists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Index()
        {
            _userUtility.GetConnection();
            return Ok("Success");
        }
        #endregion

        #region HttpPost Methods

        /// <summary>
        /// API endpoint that creates a new host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateHost(Host host)
        {
            try
            {
                if (_userUtility.CreateNewHost(host))
                {
                    return Ok("Success");
                }
                else
                {
                    return BadRequest("Failed to signup");
                }
            }
            catch
            {
                return BadRequest("Failed to signup"); 
            }
        }

        /// <summary>
        /// API endpoint that creates a new traveller
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateTraveller(Traveller traveller)
        {
            if (_userUtility.CreateNewTraveller(traveller))
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("Failed to signup");
            }
        }
        #endregion
    }
}