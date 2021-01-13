using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Com.Sapient.Utility
{
    public static class PasswordUtility
    {
        private static readonly SHA256Managed SHa256ManagedString = new SHA256Managed();
        private const string Salt = "AHmSVZRnA1PDN6crplhEAg==";

        public static string Encrypt(string input)
        {

            var bytes = Encoding.UTF8.GetBytes(input + Salt);
            var hash = SHa256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public static bool AreEqual(string plainTextInput, string hashedInput)
        {
            var newHashedPin = Encrypt(plainTextInput);
            return newHashedPin.Equals(hashedInput);
        }
    }
    
}
