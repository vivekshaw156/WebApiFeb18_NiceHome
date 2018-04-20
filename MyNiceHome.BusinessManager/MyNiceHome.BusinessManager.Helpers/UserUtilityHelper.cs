using System;
using DevOne.Security.Cryptography.BCrypt;

namespace MyNiceHome.Manager.Helpers
{
    public class UserUtilityHelper
    {
        public string GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public string GetPasswordHash(string plainTextPassword)
        {
            string salt = BCryptHelper.GenerateSalt();
            string hashedPassword = BCryptHelper.HashPassword(plainTextPassword, salt);
            return hashedPassword;
        }
    }
}
