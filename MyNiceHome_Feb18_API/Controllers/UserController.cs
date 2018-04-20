using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Entities;
using System;
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
        public async Task<OperationResult> CreateHost(Host host)
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
                        StatusCode = 201
                    };
                    return operationResult;
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = 400
                    };
                    return operationResult;
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = 400
                };
                return operationResult;
            }
        }

        /// <summary>
        /// API endpoint that creates a new traveller
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OperationResult> CreateTraveller(Traveller traveller)
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
                        StatusCode = 201
                    };
                    return operationResult;
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = 400
                    };
                    return operationResult;
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = 400
                };
                return operationResult;
            }
        }

        [HttpPost]
        public async Task<OperationResult> HostLogin(string email, string password)
        {
            try
            {
                bool result = await _userUtility.HostLoginAccess(email, password);
                if (result)
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Success",
                        Status = true,
                        StatusCode = 201
                    };
                    return operationResult;
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = 400
                    };
                    return operationResult;
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = 400
                };
                return operationResult;
            }
        }

        [HttpPost]
        public async Task<OperationResult> TravellerLogin(string email, string password)
        {
            try
            {
                bool result = await _userUtility.TravellerLoginAccess(email, password);
                if (result)
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Success",
                        Status = true,
                        StatusCode = 201
                    };
                    return operationResult;
                }
                else
                {
                    OperationResult operationResult = new OperationResult()
                    {
                        Message = "Failure",
                        Status = false,
                        StatusCode = 400
                    };
                    return operationResult;
                }
            }
            catch (Exception exception)
            {
                OperationResult operationResult = new OperationResult()
                {
                    Message = exception.Message,
                    Status = false,
                    StatusCode = 400
                };
                return operationResult;
            }
        }
        #endregion
    }
}

