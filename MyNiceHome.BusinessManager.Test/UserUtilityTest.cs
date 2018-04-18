using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using MyNiceHome.Entities;

namespace MyNiceHome.BusinessManager.Test
{
    [TestClass]
    public class UserUtilityTest
    {
        //object of UserUtility to access business layer methods
        private readonly IUserUtility _userUtility;

        #region Constructor

        public UserUtilityTest()
        {
            // initialising the UserUtility object with the mock repository object
            IRepositoryUtility mockRepositoryUtility = new RepositoryMock();
            _userUtility = new UserUtility(mockRepositoryUtility);
        }

        #endregion

        #region Valid Tests
        
        #region Host Tests

        /// <summary>
        /// Tests for creating a valid host
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewHost_ValidTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Kumar",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331234",
                HostPassword = "password123"
            };

            var result = _userUtility.CreateNewHost(host);

            Assert.IsTrue(result);
        }
        #endregion

        #region Traveller Tests
        /// <summary>
        /// Tests for creating a valid traveller
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewTraveller_ValidTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv Kumar",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331234",
                TravellerPassword = "password123"
            };

            var result = _userUtility.CreateNewTraveller(traveller);

            Assert.IsTrue(result);
        }
        #endregion

        #endregion

        #region Exception Tests

        #region Host Tests

        /// <summary>
        /// Tests if a name is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidNameException
        //[ExpectedException(typeof(InvalidNameException))]
        public void UserUtility_CreateNewHost_InvalidNameTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv@Kumar",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331234",
                HostPassword = "password123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewHost(host);
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidCityException
        //[ExpectedException(typeof(InvalidCityException))]
        public void UserUtility_CreateNewHost_InvalidCityTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Kumar",
                HostCity = "Kolkata99",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331234",
                HostPassword = "password123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewHost(host);
        }

        /// <summary>
        /// Tests if phone number is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidPhoneNumberException
        //[ExpectedException(typeof(InvalidPhoneNumberException))]
        public void UserUtility_CreateNewHost_InvalidPhoneNumberTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Kumar",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "qwert",
                HostPassword = "password123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewHost(host);
        }

        /// <summary>
        /// Tests if password is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidPasswordException
        //[ExpectedException(typeof(InvalidPasswordException))]
        public void UserUtility_CreateNewHost_InvalidPasswordTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Kumar",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331234",
                HostPassword = "123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewHost(host);
        }

        #endregion

        #region Traveller Tests

        /// <summary>
        /// Tests if a name is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidNameException
        //[ExpectedException(typeof(InvalidNameException))]
        public void UserUtility_CreateNewTraveller_InvalidNameTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv@Kumar",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331234",
                TravellerPassword = "password123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewTraveller(traveller);
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidCityException
        //[ExpectedException(typeof(InvalidCityException))]
        public void UserUtility_CreateNewTraveller_InvalidCityTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv Kumar",
                TravellerCity = "Kolkata123",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331234",
                TravellerPassword = "password123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewTraveller(traveller);
        }

        /// <summary>
        /// Tests if phone number is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidPhoneNumberException
        //[ExpectedException(typeof(InvalidPhoneNumberException))]
        public void UserUtility_CreateNewTraveller_InvalidPhoneNumberTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv Kumar",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "qwerty123",
                TravellerPassword = "password123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewTraveller(traveller);
        }

        /// <summary>
        /// Tests if password is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidPasswordException
        //[ExpectedException(typeof(InvalidPasswordException))]
        public void UserUtility_CreateNewTraveller_InvalidPasswordTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv Kumar",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331234",
                TravellerPassword = "123"
            };
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewTraveller(traveller);
        }

        #endregion

        #endregion

        #region Null Object Test

        #region Host Test
        /// <summary>
        /// Tests if the user object is null
        /// </summary>
        [TestMethod]
        // todo - expect a NullArgumentException
        //[ExpectedException(typeof(NullArgumentException))]
        public void UserUtility_CreateNewHost_NullUserTest()
        {
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewHost(null);
        }
        #endregion

        #region Traveller Test
        [TestMethod]
        // todo - expect a NullArgumentException
        //[ExpectedException(typeof(NullArgumentException))]
        public void UserUtility_CreateNewTraveller_NullUserTest()
        {
            //todo make a valid object of an user with a wrong type of name
            var result = _userUtility.CreateNewTraveller(null);
        }
        #endregion
    }
    #endregion
}