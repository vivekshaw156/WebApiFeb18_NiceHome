using System;
using DevOne.Security.Cryptography.BCrypt;

namespace MyNiceHome.Manager.Helpers
{
    /// <summary>
    /// UserUtility Helper
    /// </summary>
    public class UserUtilityHelper
    {
        /// <summary>
        /// Generating GUID
        /// </summary>
        /// <returns></returns>
        public string GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        /// <summary>
        /// Hashing Password
        /// </summary>
        /// <param name="plainTextPassword"></param>
        /// <returns></returns>
        public string GetPasswordHash(string plainTextPassword)
        {
            string salt = BCryptHelper.GenerateSalt();
            string hashedPassword = BCryptHelper.HashPassword(plainTextPassword, salt);
            return hashedPassword;
        }

        /// <summary>
        /// Matching the Password
        /// </summary>
        /// <param name="plainTextPassword"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public bool CheckPassword(string plainTextPassword, string hashedPassword)
        {
            bool check = BCryptHelper.CheckPassword(plainTextPassword, hashedPassword);
            return check;
        }
    }
}
