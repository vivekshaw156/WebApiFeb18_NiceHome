using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using MyNiceHome.Entities;
using MyNiceHome.Exceptions;
using System;

namespace MyNiceHome.BusinessManager.Test
{
    /// <summary>
    /// UserUtilityTest Class
    /// </summary>
    [TestClass]
    public class UserUtilityTest
    {
        /// <summary>
        /// ReadOnly Reference of IUserUtility Interface
        /// </summary>
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
                HostName = "Rahul Kumar",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331234",
                HostPassword = "password123"
            };

            var result = _userUtility.CreateNewHost(host);

            Assert.IsTrue(result.Result);
        }

        /// <summary>
        /// Test for Login Valid Host
        /// </summary>
        [TestMethod]
        public void UserUtility_HostLoginAccess_ValidUserExistTest()
        {
            Host host = new Host
            {
                HostEmail = "something@domainName.com",
                HostPassword = "password123"

            };
            var result = _userUtility.HostLoginAccess(host.HostEmail, host.HostPassword);

            Assert.IsTrue(result.Result);

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
                TravellerName = "Rahul Kumar",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331234",
                TravellerPassword = "password123"
            };

            var result = _userUtility.CreateNewTraveller(traveller);

            Assert.IsTrue(result.Result);
        }

        /// <summary>
        /// Tests for Login Valid Traveller
        /// </summary>
        [TestMethod]
        public void UserUtility_TravellerLoginAccess_ValidUserExistTest()
        {
           Traveller traveller = new Traveller
            {
                TravellerEmail = "something@domainName.com",
                TravellerPassword = "password123"

            };
            var result = _userUtility.TravellerLoginAccess(traveller.TravellerEmail, traveller.TravellerPassword);

            Assert.IsTrue(result.Result);

        }

        #endregion

        #endregion

        #region Exception Tests

        #region Host Tests

        /// <summary>
        /// Tests if a name is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewHost(host).Result;
            }
            catch(AggregateException exception)
            {
                Assert.AreEqual(typeof(InvalidNameException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
        public  void UserUtility_CreateNewHost_InvalidCityTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Kumar",
                HostCity = "Kolkata99",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331234",
                HostPassword = "password123"
            };
            try
            {
                var result = _userUtility.CreateNewHost(host);
            }
            catch(AggregateException exception)
            {
                Assert.AreEqual(typeof(InvalidCityException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewHost_InvalidEmailTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Kumar",
                HostCity = "Kolkata",
                HostEmail = "......@do...mainName.com",
                HostPhone = "9674331234",
                HostPassword = "password123"
            };
            try
            {
                var result = _userUtility.CreateNewHost(host);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidEmailException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if phone number is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewHost(host);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidPhoneNumberException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if password is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewHost(host);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidPasswordException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if a duplicate entry exists in the database
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewHost_DuplicateEntryTest()
        {
            Host host = new Host
            {
                HostName = "Rajiv Thakur",
                HostCity = "Kolkata",
                HostEmail = "something@domainName.com",
                HostPhone = "9674331556",
                HostPassword = "qwerty123"
            };
            try
            {
                var result = _userUtility.CreateNewHost(host);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(DuplicateEntryException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        ///  Test if User Exist in DataBase
        /// </summary>
        [TestMethod]
        public void UserUtility_HostLoginAccess_InvalidUserExistTest()
        {
            Host host = new Host
            {
                HostEmail = "some@yahoo.com",
                HostPassword = "768956435"
            };
            try
            {
                var result = _userUtility.HostLoginAccess(host.HostEmail, host.HostPassword);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(UserDoesNotExistException), exception.InnerException.GetType());
            }
        }

        #endregion

        #region Traveller Tests

        /// <summary>
        /// Tests if a name is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewTraveller(traveller);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidNameException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewTraveller(traveller);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidCityException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewTraveller_InvalidEmailTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv Kumar",
                TravellerCity = "Kolkata",
                TravellerEmail = ".....a..@d..omainName.com",
                TravellerPhone = "9674331234",
                TravellerPassword = "password123"
            };
            try
            {
                var result = _userUtility.CreateNewTraveller(traveller);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidEmailException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if phone number is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewTraveller(traveller);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidPhoneNumberException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if password is invalid
        /// </summary>
        [TestMethod]
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
            try
            {
                var result = _userUtility.CreateNewTraveller(traveller);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(InvalidPasswordException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Tests if a duplicate entry exists in the database
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewTraveller_DuplicateEntryTest()
        {
            Traveller traveller = new Traveller
            {
                TravellerName = "Rajiv Thakur",
                TravellerCity = "Kolkata",
                TravellerEmail = "something@domainName.com",
                TravellerPhone = "9674331556",
                TravellerPassword = "qwerty123"
            };
            try
            {
                var result = _userUtility.CreateNewTraveller(traveller);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(DuplicateEntryException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        ///  Test if User Exist in DataBase
        /// </summary>
        [TestMethod]
        public void UserUtility_TravellerLoginAccess_InvalidUserExistTest()
        {

            Traveller traveller = new Traveller
            {
                TravellerEmail = "something@yahoo.com",
                TravellerPassword = "879657854"
            };
            try
            {
                var result = _userUtility.HostLoginAccess(traveller.TravellerEmail, traveller.TravellerPassword);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(UserDoesNotExistException), exception.InnerException.GetType());
            }
        }

        #endregion

        #endregion

        #region Null Object Test

        #region Host Test
        /// <summary>
        /// Tests if the Host is Null
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewHost_NullUserTest()
        {
            try
            {
                var result = _userUtility.CreateNewHost(null);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(NullReferenceException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Host Null Test
        /// </summary>
        [TestMethod]
        public void UserUtility_HostLoginAccess_NullUserExistTest()
        {
            try
            {
                var result = _userUtility.HostLoginAccess(null, null);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(NullReferenceException), exception.InnerException.GetType());
            }
        }


        #endregion

        #region Traveller Test
        /// <summary>
        /// Null Traveller Test
        /// </summary>
        [TestMethod]
        public void UserUtility_CreateNewTraveller_NullUserTest()
        {
            try
            {
                var result = _userUtility.CreateNewTraveller(null);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(NullReferenceException), exception.InnerException.GetType());
            }
        }

        /// <summary>
        /// Null Traveller Test
        /// </summary>
        [TestMethod]
        public void UserUtility_TravellerLoginAccess_NullUserExistTest()
        {
            try
            {
                var result = _userUtility.TravellerLoginAccess(null, null);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(typeof(NullReferenceException), exception.InnerException.GetType());
            }
        }

        #endregion
    }
    #endregion
}