using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
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

        /// <summary>
        /// API endpoint that creates a new host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateHost(Host host)
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

    }
}
