using System;

namespace Gr8Food
{
    public static class InputValidator
    {
        public static string ValidateUsername(string username)
        {
            string value = NormalizeRequired(username, "Username");
            if (value.Length < 3 || value.Length > 50)
            {
                throw new InvalidOperationException("Username must be between 3 and 50 characters.");
            }

            return value;
        }

        public static string ValidateFullName(string fullName)
        {
            string value = NormalizeRequired(fullName, "Full name");
            if (value.Length < 3 || value.Length > 100)
            {
                throw new InvalidOperationException("Full name must be between 3 and 100 characters.");
            }

            return value;
        }

        public static string ValidatePassword(string password)
        {
            string value = NormalizeRequired(password, "Password");
            if (value.Length < 3 || value.Length > 50)
            {
                throw new InvalidOperationException("Password must be between 3 and 50 characters.");
            }

            return value;
        }

        public static string ValidateRole(string role)
        {
            string value = NormalizeRequired(role, "Role");
            if (!DomainRules.ContainsIgnoreCase(DomainRules.Roles, value))
            {
                throw new InvalidOperationException("Please select a valid role.");
            }

            return value;
        }

        public static string ValidateCategory(string category)
        {
            string value = NormalizeRequired(category, "Category");
            if (!DomainRules.ContainsIgnoreCase(DomainRules.MenuCategories, value))
            {
                throw new InvalidOperationException("Please select a valid menu category.");
            }

            return value;
        }

        public static string ValidateMenuItemName(string name)
        {
            string value = NormalizeRequired(name, "Menu item name");
            if (value.Length > 100)
            {
                throw new InvalidOperationException("Menu item name must not exceed 100 characters.");
            }

            return value;
        }

        public static decimal ValidatePositiveAmount(string label, decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(label + " must be greater than zero.");
            }

            return decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        }

        public static string ValidateFeedbackMessage(string message, string label)
        {
            string value = NormalizeRequired(message, label);
            if (value.Length > 500)
            {
                throw new InvalidOperationException(label + " must not exceed 500 characters.");
            }

            return value;
        }

        private static string NormalizeRequired(string value, string fieldName)
        {
            string trimmed = value == null ? string.Empty : value.Trim();
            if (trimmed.Length == 0)
            {
                throw new InvalidOperationException(fieldName + " is required.");
            }

            return trimmed;
        }
    }
}
