using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> CreateHost(Host host)
        {
            try
            {
                bool result = await _userUtility.CreateNewHost(host);
                if (result)
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Success",
                        Status = true,
                        StatusCode = HttpStatusCode.OK
                    };
                    return Ok(operationResult);
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    return BadRequest(operationResult.Message);
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
                return BadRequest(operationResult.Message);
            }
        }

        /// <summary>
        /// API endpoint that creates a new traveller
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> CreateTraveller(Traveller traveller)
        {
            try
            {
                bool result = await _userUtility.CreateNewTraveller(traveller);
                if (result)
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Success",
                        Status = true,
                        StatusCode = HttpStatusCode.OK
                    };
                    return Ok(operationResult);
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    return BadRequest(operationResult.Message);
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
                return BadRequest(operationResult.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> HostLogin([FromBody] LoginData loginData)
        {
            try
            {
                bool result = await _userUtility.HostLoginAccess(loginData.Email, loginData.Password);
                if (result)
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Success",
                        Status = true,
                        StatusCode = HttpStatusCode.OK
                    };
                    return Ok(operationResult);
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    return BadRequest(operationResult.Message);
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
                return BadRequest(operationResult.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> TravellerLogin([FromBody] LoginData loginData)
        {
            try
            {
                bool result = await _userUtility.TravellerLoginAccess(loginData.Email, loginData.Password);
                if (result)
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Success",
                        Status = true,
                        StatusCode = HttpStatusCode.OK
                    };
                    return Ok(operationResult);
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    return BadRequest(operationResult.Message);
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
                return BadRequest(operationResult.Message);
            }
        }
        #endregion
    }
}
