using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;

namespace MyNiceHome.BusinessManager.Test
{
    [TestClass]
    public class UserUtilityTest
    {
        // object of UserUtility to access business layer methods
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

        [TestMethod]
        public void UserUtility_NewUser_ValidTest()
        {
            //todo make a valid object of an user
            //var result = _userUtility.CreateHost();

            //Assert.IsTrue(result);
        }

        #endregion

#region Exception Tests

        /// <summary>
        /// Tests if a name is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidNameException
        //[ExpectedException(typeof(InvalidNameException))]
        public void UserUtility_NewUser_InvalidNameTest()
        {
            //todo make a valid object of an user with a wrong type of name
            //var result = _userUtility.Create();
        }

        /// <summary>
        /// Tests if city is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidCityException
        //[ExpectedException(typeof(InvalidCityException))]
        public void UserUtility_NewUser_InvalidCityTest()
        {
            //todo make a valid object of an user with a wrong type of name
            //var result = _userUtility.Create();
        }

        /// <summary>
        /// Tests if email is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidEmailException
        //[ExpectedException(typeof(InvalidEmailException))]
        public void UserUtility_NewUser_InvalidEmailTest()
        {
            //todo make a valid object of an user with a wrong type of name
            //var result = _userUtility.Create();
        }

        /// <summary>
        /// Tests if phone number is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidPhoneNumberException
        //[ExpectedException(typeof(InvalidPhoneNumberException))]
        public void UserUtility_NewUser_InvalidPhoneNumberTest()
        {
            //todo make a valid object of an user with a wrong type of name
            //var result = _userUtility.Create();
        }

        /// <summary>
        /// Tests if password is invalid
        /// </summary>
        [TestMethod]
        // todo - expect an InvalidPasswordException
        //[ExpectedException(typeof(InvalidPasswordException))]
        public void UserUtility_NewUser_InvalidPasswordTest()
        {
            //todo make a valid object of an user with a wrong type of name
            //var result = _userUtility.Create();
        }
        #endregion

#region Null Object Test
        /// <summary>
        /// Tests if the user object is null
        /// </summary>
        [TestMethod]
        // todo - expect a NullArgumentException
        //[ExpectedException(typeof(NullArgumentException))]
        public void UserUtility_NewUser_NullUserTest()
        {
            //todo make a valid object of an user with a wrong type of name
            //var result = _userUtility.Create();
        }
    }
#endregion
}
