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
        public bool CreateNewHost(Host host)
        {
            //todo-checking null value in all the fields
            if (host == null)
            {
                throw new ArgumentNullException("host");
            }
            var patternName = new Regex(" ^[A-Za-z] + $");
            var patternCity = new Regex("/^([^0-9]*)$/");
            var patternEmail = new Regex("^[_a - z0 - 9 -] + (.[a - z0 - 9 -] +)@[a - z0 - 9 -] + (.[a - z0 - 9 -] +) * (.[a - z]{ 2,4})$");
            //checking invalid entry for name field
            if (host.HostName == null || !patternName.IsMatch(host.HostName))
            {
                throw new InvalidNameException("Please enter a valid name");
            }
            //checking invalid entry for city field
            else if (host.HostCity == null || !patternCity.IsMatch(host.HostCity))
            {
                throw new InvalidCityException("Please enter a valid city");
            }
            //checking invalid entry for email field
            else if (host.HostEmail == null || !patternEmail.IsMatch(host.HostEmail))
            {
                throw new InvalidEmailException("Please enter a valid email");
            }
            //checking invalid entry for phone number field
            else if (host.HostPhone == null || host.HostPhone.Length != 10 || !(host.HostPhone.Substring(0, 1).Equals(6) || host.HostPhone.Substring(0, 1).Equals(7) || host.HostPhone.Substring(0, 1).Equals(8) || host.HostPhone.Substring(0, 1).Equals(9)))
            {
                throw new InvalidPhoneNumberException("Please enter a valid phone number");
            }
            //checking invalid entry for password field
            else if (host.HostPassword == null || host.HostPassword.Length < 8)
            {
                throw new InvalidPasswordException("Please enter a valid password");
            }
            else if(_repositoryUtility.CheckIfHostExists(host))
            {
                throw new DuplicateEntryException("Host already exists"); 
            }
            try
            {
                return _repositoryUtility.AddHost(host);
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
        public bool CreateNewTraveller(Traveller traveller)
        {
            //todo-checking null value in all the fields
            if (traveller == null)
            {
                throw new ArgumentNullException("traveller");
            }
            var patternName = new Regex(" ^[A-Za-z] + $");
            var patternCity = new Regex("/^([^0-9]*)$/");
            var patternEmail = new Regex("^[_a - z0 - 9 -] + (.[a - z0 - 9 -] +)@[a - z0 - 9 -] + (.[a - z0 - 9 -] +) * (.[a - z]{ 2,4})$");
            //todo - checking null entry
            if (traveller.TravellerName == null || !patternName.IsMatch(traveller.TravellerName))
            {
                throw new InvalidNameException("Please enter a valid name");
            }
            //todo - checking invalid entry for city field
            else if (traveller.TravellerCity == null || !patternCity.IsMatch(traveller.TravellerCity))
            {
                throw new InvalidCityException("Please enter a valid city");
            }
            //todo- checking invalid entry for email field
            else if (traveller.TravellerEmail == null || !patternEmail.IsMatch(traveller.TravellerEmail))
            {
                throw new InvalidEmailException("Please enter a valid email");
            }
            //todo- checking invalid entry for phone number field
            else if (traveller.TravellerPhone == null || traveller.TravellerPhone.Length != 10 || !(traveller.TravellerPhone.Substring(0, 1).Equals(6) || traveller.TravellerPhone.Substring(0, 1).Equals(7) || traveller.TravellerPhone.Substring(0, 1).Equals(8) || traveller.TravellerPhone.Substring(0, 1).Equals(9)))
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
                return _repositoryUtility.AddTraveller(traveller);
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
