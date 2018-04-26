using MyNiceHome.BusinessManager.Interfaces;
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
            var patternName = new Regex(@"^[a-zA-Z][a-z A-Z\s-]+$");
            var patternCity = new Regex(@"^[A-Z]+$");
            //var patternEmail = new Regex(@"^[a-zA-Z0-9](\.?[a-zA-Z0-9]){1,}@([a-zA-Z]+)\.com$");
            var patternPhone = new Regex(@"^[0-9]*$");

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

            var patternName = new Regex(@"^[a-zA-Z][a-z A-Z\s-]+$");
            var patternCity = new Regex(@"^[A-Z]+$");
            //var patternEmail = new Regex(@"^[a-zA-Z0-9](\.?[a-zA-Z0-9]){1,}@([a-zA-Z]+)\.com$");
            var patternPhone = new Regex(@"^[0-9]*$");

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
            if (email==null || password==null)
            {
                throw new UserDoesNotExistException("Email or password cannot be null");
            }

         
            string hashedPassword = await _repositoryUtility.IsValidHostLogin(email);
            if(hashedPassword==null)
            {
                throw new UserDoesNotExistException("Email not registered for host");
            }
            bool isSame = _userUtilityHelper.CheckPassword(password, hashedPassword);
            if(isSame==true)
            {
                //code to generate access token
                JwtTokenHelper tokenobj = new JwtTokenHelper();
                string tokenString = tokenobj.GenerateToken(email,"host");

                
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
