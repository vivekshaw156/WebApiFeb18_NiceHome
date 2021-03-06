﻿using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using System;
using System.Threading.Tasks;
using MyNiceHome.Entities;
using System.Text.RegularExpressions;
using MyNiceHome.Exceptions;
using MyNiceHome.Manager.Helpers;
using MyNiceHome.BusinessManager.MyNiceHome.BusinessManager.Helpers;

namespace MyNiceHome.BusinessManager
{
    /// <summary>
    /// UserUtility Class representing User Utilities
    /// </summary>
    public class UserUtility : IUserUtility
    {
        /// <summary>
        /// ReadOnly Reference for IRepositoryUtility Interface
        /// </summary>
        private readonly IRepositoryUtility _repositoryUtility;

        /// <summary>
        /// ReadOnly Reference for UserUtilityHelper Class
        /// </summary>
        private readonly UserUtilityHelper _userUtilityHelper;

        private readonly MailHelper _mailHelper;

        /// <summary>
        /// UserUtility Constructor
        /// </summary>
        /// <param name="repositoryUtility"></param>
        public UserUtility(IRepositoryUtility repositoryUtility)
        {
            _userUtilityHelper = new UserUtilityHelper();
            _repositoryUtility = repositoryUtility;
            _mailHelper = new MailHelper();
        }

        /// <summary>
        /// Sender Method for Adding Host Details
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewHost(Host host)
        {
            var cityHost = (host.HostCity).ToUpper();

            var patternName = new Regex(@"^[a-zA-Z]+([\s][a-zA-Z]+)*$");
            var patternCity = new Regex(@"^[a-zA-Z]+([\s][a-zA-Z]+)*$");
            var patternPhone = new Regex(@"^[6-9][0-9]{9}$");
            


            if (host == null)
            {
                throw new NullReferenceException("host");
            }
            if (host.HostName == null || !(patternName.Match(host.HostName).Success))
            {
                throw new InvalidNameException("Please enter a valid name");
            }
            if (host.HostCity == null || !(patternCity.Match(cityHost).Success))
            {
                throw new InvalidCityException("Please enter a valid city");
            }
            if (host.HostEmail == null)
            {
                throw new InvalidEmailException("Please enter a valid email");
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(host.HostEmail);
            }
            catch
            {
                new InvalidEmailException("Please enter a valid email");
            }
            if (host.HostPhone == null || host.HostPhone.Length != 10 || !(patternPhone.Match(host.HostPhone).Success))
            {
                throw new InvalidPhoneNumberException("Please enter a valid phone number");
            }
            if (host.HostPassword == null || host.HostPassword.Length < 8)
            {
                throw new InvalidPasswordException("Please enter a valid password");
            }
            if (await _repositoryUtility.CheckIfHostExists(host))
            {
                throw new DuplicateEntryException("Host already exists");
            }
            try
            {
                host.HID = _userUtilityHelper.GenerateGuid();

                string enteredPassword = host.HostPassword;
                host.HostPassword = _userUtilityHelper.GetPasswordHash(enteredPassword);

                host.HostName = host.HostName.ToUpper();
                host.HostCity = host.HostCity.ToUpper();
                
                if (await _repositoryUtility.AddHost(host))
                {
                    _mailHelper.sendTo(host.HostEmail,"Successful Host Registeration", "Congrats!! You are a Registered Host");
                    return true;
                }
                else { return false; }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Sender Method for Adding Traveller Details
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewTraveller(Traveller traveller)
        {
            traveller.TravellerCity = (traveller.TravellerCity).ToUpper();

            var patternName = new Regex(@"^[a-zA-Z]+([\s][a-zA-Z]+)*$");
            var patternCity = new Regex(@"^[a-zA-Z]+([\s][a-zA-Z]+)*$");
            var patternPhone = new Regex(@"^[6-9][0-9]{9}$");


            if (traveller == null)
            {
                throw new ArgumentNullException("traveller");
            }
            if (traveller.TravellerName == null || !(patternName.Match(traveller.TravellerName).Success))
            {
                throw new InvalidNameException("Please enter a valid name");
            }
            //checking invalid entry for city field
            if (traveller.TravellerCity == null || !(patternCity.Match(traveller.TravellerCity).Success))
            {
                throw new InvalidCityException("Please enter a valid city");
            }
            //checking invalid entry for email field
            if (traveller.TravellerEmail == null)
            {
                throw new InvalidEmailException("Please enter a valid email");
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(traveller.TravellerEmail);
            }
            catch
            {
                throw new InvalidEmailException("Please enter a valid email");
            }

            //checking invalid entry for phone number field
            if (traveller.TravellerPhone == null || traveller.TravellerPhone.Length != 10 || !(patternPhone.Match(traveller.TravellerPhone).Success))
            {
                throw new InvalidPhoneNumberException("Please enter a valid phone number");
            }
            //checking invalid entry for password field
            if (traveller.TravellerPassword == null || traveller.TravellerPassword.Length < 8)
            {
                throw new InvalidPasswordException("Please enter a valid password");
            }
            if (await _repositoryUtility.CheckIfTravellerExists(traveller))
            {
                throw new DuplicateEntryException("Traveller already exists");
            }
            try
            {
                traveller.TID = _userUtilityHelper.GenerateGuid();

                string enteredPassword = traveller.TravellerPassword;
                traveller.TravellerPassword = _userUtilityHelper.GetPasswordHash(enteredPassword);

                traveller.TravellerName = traveller.TravellerName.ToUpper();
                traveller.TravellerCity = traveller.TravellerCity.ToUpper();

                if (await _repositoryUtility.AddTraveller(traveller))
                {
                    _mailHelper.sendTo(traveller.TravellerEmail, "Successful Traveller Registeration", "Congrats!! You are a Registered Traveller");
                    return true;
                }
                else { return false; }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Method for Host Login Access
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> HostLoginAccess(string email, string password)
        {
            //checking null Object
            if (email == null && password == null)
            {
                throw new NullReferenceException("host");
            }

            //checking null fields
            if (email == null || password == null)
            {
                throw new UserDoesNotExistException("Email or password cannot be null");
            }


            string hashedPassword = await _repositoryUtility.IsValidHostLogin(email);
            if (hashedPassword == null)
            {
                throw new UserDoesNotExistException("Email not registered for host");
            }
            bool isSame = _userUtilityHelper.CheckPassword(password, hashedPassword);
            if (isSame == true)
            {
                //code to generate access token
                JwtTokenHelper tokenobj = new JwtTokenHelper();
                string tokenString = tokenobj.GenerateToken(email, "host");


            }
            return await Task.FromResult(isSame);
        }

        /// <summary>
        /// Method for Traveller Login Access
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> TravellerLoginAccess(string email, string password)
        {
            //checking for null objects
            if (email == null && password == null)
            {
                throw new NullReferenceException("Traveller");
            }
            //checking for null fields
            if (email == null || password == null)
            {
                throw new UserDoesNotExistException("Email or password cannot be null");
            }
            string hashedPassword = await _repositoryUtility.IsValidTravellerLogin(email);
            if (hashedPassword == null)
            {
                throw new UserDoesNotExistException("Email not registered for traveller");
            }
            bool isSame = _userUtilityHelper.CheckPassword(password, hashedPassword);
            return (isSame);
        }

        /// <summary>
        /// Method for sending mail to reset HostPassword 
        /// </summary>
        /// <param name="email"></param>
        public Boolean ResetHostPassword(string email)
        {
            string hostId = _repositoryUtility.IsValidHost(email);
            if (hostId == null)
            {
                throw new UserDoesNotExistException("Email does not exist");
            }
            try
            {
                MailHelper mailHelper = new MailHelper();
                string subject = "Reset password Link";
                string body = "https://mynicehomefeb2018prodfrontend.azurewebsites.net/reset-password?id=" + hostId;
                mailHelper.sendTo(email, subject, body);
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// Method for sending mail to reset TravellerPassword
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Boolean ResetTravellerPassword(string email)
        {
            string travellerGuid = _repositoryUtility.IsValidTraveller(email);
            if (travellerGuid == null)
            {
                throw new UserDoesNotExistException("Email does not exist");
            }
            try
            {
                MailHelper mailHelper = new MailHelper();
                string subject = "Reset password Link";
                string body = "https://mynicehomefeb2018qafrontend.azurewebsites.net/reset-password-traveller?id=" + travellerGuid;
                mailHelper.sendTo(email, subject, body);
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// Sender Method to Update HostPassword
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="hostId"></param>
        /// <returns></returns>
        public bool ResetNewHostPassword(string newPassword, string hostId)
        {
            try
            {

                string hashedPassword = _userUtilityHelper.GetPasswordHash(newPassword);


                bool result = _repositoryUtility.CreateNewHostPassword(hashedPassword, hostId);
                return result;
            }
            catch(Exception exception)
            {
                throw exception;
            }

        }
        /// <summary>
        /// Sender Method to Update TravellerPassword
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="travellerId"></param>
        /// <returns></returns>
        public bool ResetNewTravellerPassword(string newPassword, string travellerId)
        {
            try
            {

                string hashedPassword = _userUtilityHelper.GetPasswordHash(newPassword);


                bool result = _repositoryUtility.CreateNewTravellerPassword(hashedPassword, travellerId);
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        /// <summary>
        /// Method for Creating New Connection
        /// </summary>
        /// <returns></returns>
        public bool GetConnection()
        {
            _repositoryUtility.GetNewConnection();
            return true;
        }
    }
}
