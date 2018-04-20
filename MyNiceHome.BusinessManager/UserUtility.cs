using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNiceHome.Entities;
using System.Text.RegularExpressions;
using MyNiceHome.Exceptions;

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
        /// UserUtility Constructor
        /// </summary>
        /// <param name="repositoryUtility"></param>
        public UserUtility(IRepositoryUtility repositoryUtility)
        {
            _repositoryUtility = repositoryUtility;
        }

        /// <summary>
        /// Sender Method for Adding Host Details
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public Task<bool> CreateNewHost(Host host)
        {
            //  var patternName = new Regex(@"/^[^-\s][a-zA-Z \s-]+$");
           // host.HostName = (host.HostName).ToUpper();
            var cityHost=(host.HostCity).ToUpper();

            var patternName = new Regex(@"^[a-zA-Z][a-z A-Z\s-]+$");
            //checking invalid entry for name field

            var patternCity = new Regex(@"^[A-Z]+$");

            var patternEmail = new Regex(@"^[a-zA-Z0-9](\.?[a-zA-Z0-9]){1,}@([a-zA-Z]+)\.com$");
            var patternPhone = new Regex(@"^[0-9]*$");
            
            if (host == null)
            {
                throw new ArgumentNullException("host");
            }
            else if (host.HostName == null || !(patternName.Match(host.HostName).Success))
            {
                throw new InvalidNameException("Please enter a valid name");
            }
            //checking invalid entry for city field
            else if (host.HostCity == null || !(patternCity.Match(cityHost).Success))
            {
                throw new InvalidCityException("Please enter a valid city");
            }
            //checking invalid entry for email field
            else if (host.HostEmail == null || !(patternEmail.Match(host.HostEmail).Success))
            {
                throw new InvalidEmailException("Please enter a valid email");
            }
            //checking invalid entry for phone number field
           else if (host.HostPhone == null || host.HostPhone.Length!=10 || !(patternPhone.Match(host.HostPhone).Success))
            {
                throw new InvalidPhoneNumberException("Please enter a valid phone number");
            }
            //checking invalid entry for password field
            else if (host.HostPassword == null || host.HostPassword.Length<8)
            {
                throw new InvalidPasswordException("Please enter a valid password");
            }
            else if(_repositoryUtility.CheckIfHostExists(host))
            {
                throw new DuplicateEntryException("Host already exists"); 
            }
            try
            {
                Guid guid = Guid.NewGuid();
                host.HID = guid.ToString();

                string enteredPassword = host.HostPassword;
                string salt = DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt();
                string hashedPassword = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(enteredPassword, salt);
                host.HostPassword = hashedPassword;

                return Task.FromResult(_repositoryUtility.AddHost(host));
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Sender Method for Adding Traveller Details
        /// </summary>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public Task<bool> CreateNewTraveller(Traveller traveller)
        {
            traveller.TravellerCity = (traveller.TravellerCity).ToUpper();

            var patternName = new Regex(@"^[a-zA-Z][a-z A-Z\s-]+$");
            //checking invalid entry for name field

            var patternCity = new Regex(@"^[A-Z]+$");

            var patternEmail = new Regex(@"^[a-zA-Z0-9](\.?[a-zA-Z0-9]){1,}@([a-zA-Z]+)\.com$");
            var patternPhone = new Regex(@"^[0-9]*$");

            if (traveller == null)
            {
                throw new ArgumentNullException("host");
            }
            else if (traveller.TravellerName == null || !(patternName.Match(traveller.TravellerName).Success))
            {
                throw new InvalidNameException("Please enter a valid name");
            }
            //checking invalid entry for city field
            else if (traveller.TravellerCity == null || !(patternCity.Match(traveller.TravellerCity).Success))
            {
                throw new InvalidCityException("Please enter a valid city");
            }
            //checking invalid entry for email field
            else if (traveller.TravellerEmail == null || !(patternEmail.Match(traveller.TravellerEmail).Success))
            {
                throw new InvalidEmailException("Please enter a valid email");
            }
            //checking invalid entry for phone number field
            else if (traveller.TravellerPhone == null || traveller.TravellerPhone.Length != 10 || !(patternPhone.Match(traveller.TravellerPhone).Success))
            {
                throw new InvalidPhoneNumberException("Please enter a valid phone number");
            }
            //todo- checking invalid entry for password field
            else if (traveller.TravellerPassword == null || traveller.TravellerPassword.Length < 8)
            {
                throw new InvalidPasswordException("Please enter a valid password");
            }
            else if (_repositoryUtility.CheckIfTravellerExists(traveller))
            {
                throw new DuplicateEntryException("Traveller already exists");
            }
            try
            {
                Guid guid = Guid.NewGuid();
                traveller.TID = guid.ToString();

                string enteredPassword = traveller.TravellerPassword;
                string salt = DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt();
                string hashedPassword = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(enteredPassword, salt);
                traveller.TravellerPassword = hashedPassword;

                return Task.FromResult(_repositoryUtility.AddTraveller(traveller));
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
