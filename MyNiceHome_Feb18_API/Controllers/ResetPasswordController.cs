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
    /// ResetPassword class
    /// </summary>
    public class ResetPasswordController : ApiController
    {
        /// <summary>
        /// Readonly reference for IUserUtility
        /// </summary>
        private readonly IUserUtility _userUtility;

        /// <summary>
        /// Constructor foe ResetPassword Class
        /// </summary>
        /// <param name="userUtility"></param>
        public ResetPasswordController(IUserUtility userUtility)
        {
            _userUtility = userUtility;
        }

        #region HttpPost Method

        /// <summary>
        /// Accepting request for reset Host Password
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ResetPasswordHost([FromBody] LoginData loginData)
        {
            try
            {
                bool result = _userUtility.ResetHostPassword(loginData.Email);
                OperationResult operationResult = new OperationResult();
                if (result == true)
                {
                    operationResult.Message = "Please check your mail";
                    operationResult.Status = true;
                    operationResult.StatusCode = HttpStatusCode.OK;

                }
                return Ok(operationResult);
            }
            catch
            {
                return BadRequest("Unable to verify email");
            }
        }

        /// <summary>
       /// Accepting request for reset Traveller Password
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ResetPasswordTraveller([FromBody] LoginData loginData)
        {
            try
            {
                bool result = _userUtility.ResetTravellerPassword(loginData.Email);
                OperationResult operationResult = new OperationResult();
                if (result == true)
                {
                    operationResult.Message = "Please check your mail";
                    operationResult.Status = true;
                    operationResult.StatusCode = HttpStatusCode.OK;

                }
                return Ok(operationResult);
            }
            catch
            {
                return BadRequest("Unable to verify email");
            }
        }

        /// <summary>
        /// Updating the password for Host
        /// </summary>
        /// <param name="loginData"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]

        public IHttpActionResult ResetNewPasswordHost([FromBody] LoginData loginData, string id)
        {
            try
            {
                bool result = _userUtility.ResetNewHostPassword(loginData.Password, id);
                OperationResult operationResult = new OperationResult();
                if (result)
                {
                    operationResult.Message = "Password successfully updated";
                    operationResult.Status = true;
                    operationResult.StatusCode = HttpStatusCode.OK;

                }
                return Ok(operationResult);
            }
            catch
            {
                return BadRequest("Unable to update password");
            }


        }
        /// <summary>
        /// Updating the password for Traveller
        /// </summary>
        /// <param name="loginData"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ResetNewPasswordTraveller([FromBody] LoginData loginData, string id)
        {
            try
            {
                bool result = _userUtility.ResetNewTravellerPassword(loginData.Password, id);
                OperationResult operationResult = new OperationResult();
                if (result)
                {
                    operationResult.Message = "Password successfully updated";
                    operationResult.Status = true;
                    operationResult.StatusCode = HttpStatusCode.OK;

                }
                return Ok(operationResult);
            }
            catch
            {
                return BadRequest("Unable to update password");
            }


        }
        #endregion
    }
}



