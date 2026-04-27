using System;
using System.Security.Cryptography;
using System.Text;

namespace Gr8Food
{
    public static class PasswordUtility
    {
        private const string HashPrefix = "HASH$";

        public static string HashPassword(string password)
        {
            string value = InputValidator.ValidatePassword(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                return HashPrefix + Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            if (string.IsNullOrWhiteSpace(storedPassword))
            {
                return false;
            }

            if (IsHashedPassword(storedPassword))
            {
                return string.Equals(HashPassword(enteredPassword), storedPassword, StringComparison.Ordinal);
            }

            return string.Equals(enteredPassword, storedPassword, StringComparison.Ordinal);
        }

        public static bool IsHashedPassword(string storedPassword)
        {
            return !string.IsNullOrWhiteSpace(storedPassword)
                && storedPassword.StartsWith(HashPrefix, StringComparison.Ordinal);
        }
    }
}
