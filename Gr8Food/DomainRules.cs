using System;

namespace Gr8Food
{
    public static class DomainRules
    {
        public const string RoleAdmin = "Admin";
        public const string RoleManager = "Manager";
        public const string RoleChef = "Chef";
        public const string RoleCustomer = "Customer";

        public const string CategoryBreakfast = "Breakfast";
        public const string CategoryLunch = "Lunch";
        public const string CategoryDinner = "Dinner";
        public const string CategorySnacks = "Snacks";
        public const string CategoryDrinks = "Drinks";
        public const string CategoryAll = "All";

        public const string OrderStatusPending = "Pending";
        public const string OrderStatusInProgress = "In Progress";
        public const string OrderStatusCompleted = "Completed";
        public const string OrderStatusCancelled = "Cancelled";

        public const string WalletTypeTopUp = "Top Up";
        public const string WalletTypePayment = "Payment";
        public const string WalletTypeRefund = "Refund";

        public static readonly string[] Roles =
        {
            RoleAdmin,
            RoleManager,
            RoleChef,
            RoleCustomer
        };

        public static readonly string[] MenuCategories =
        {
            CategoryBreakfast,
            CategoryLunch,
            CategoryDinner,
            CategorySnacks,
            CategoryDrinks
        };

        public static readonly string[] ReportCategories =
        {
            CategoryAll,
            CategoryBreakfast,
            CategoryLunch,
            CategoryDinner,
            CategorySnacks,
            CategoryDrinks
        };

        public static readonly string[] OrderStatuses =
        {
            OrderStatusPending,
            OrderStatusInProgress,
            OrderStatusCompleted,
            OrderStatusCancelled
        };

        public static readonly string[] WalletTransactionTypes =
        {
            WalletTypeTopUp,
            WalletTypePayment,
            WalletTypeRefund
        };

        public static bool ContainsIgnoreCase(string[] values, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            foreach (string candidate in values)
            {
                if (string.Equals(candidate, value.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
