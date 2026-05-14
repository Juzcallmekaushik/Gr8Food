using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class SalesReportItem
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string ChefName { get; set; }
        public string CustomerName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return string.Format(
                "#{0} | {1} | RM {2:0.00} | {3} | Chef: {4} | {5:MMM yyyy}",
                OrderId,
                ItemName,
                Price,
                Category,
                ChefName,
                OrderDate);
        }
    }

    public static class AppRepository
    {
        public static User Authenticate(string username, string password)
        {
            username = InputValidator.ValidateUsername(username);
            password = InputValidator.ValidatePassword(password);

            const string sql = @"
SELECT UserId, Username, FullName, [Password], [Role], WalletBalance
FROM dbo.Users
WHERE Username = @Username AND IsDeleted = 0;";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    int userId = Convert.ToInt32(reader["UserId"]);
                    string storedPassword = Convert.ToString(reader["Password"]);
                    if (!PasswordUtility.VerifyPassword(password, storedPassword))
                    {
                        return null;
                    }

                    reader.Close();

                    if (!PasswordUtility.IsHashedPassword(storedPassword))
                    {
                        UpdateStoredPassword(userId, PasswordUtility.HashPassword(password));
                    }

                    return GetUserById(userId);
                }
            }
        }

        public static User GetUserById(int userId)
        {
            const string sql = @"
SELECT UserId, Username, FullName, [Password], [Role], WalletBalance
FROM dbo.Users
WHERE UserId = @UserId AND IsDeleted = 0;";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapUser(reader) : null;
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            const string sql = @"
SELECT UserId, Username, FullName, [Password], [Role], WalletBalance
FROM dbo.Users
WHERE IsDeleted = 0
ORDER BY [Role], Username;";

            List<User> users = new List<User>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(MapUser(reader));
                    }
                }
            }

            return users;
        }

        public static List<User> GetUsersByRole(string role)
        {
            const string sql = @"
SELECT UserId, Username, FullName, [Password], [Role], WalletBalance
FROM dbo.Users
WHERE [Role] = @Role
  AND IsDeleted = 0
ORDER BY Username;";

            List<User> users = new List<User>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Role", role);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(MapUser(reader));
                    }
                }
            }

            return users;
        }

        public static void AddUser(string username, string fullName, string password, string role)
        {
            username = InputValidator.ValidateUsername(username);
            fullName = InputValidator.ValidateFullName(fullName);
            password = InputValidator.ValidatePassword(password);
            role = InputValidator.ValidateRole(role);

            const string sql = @"
INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
VALUES (@Username, @FullName, @Password, @Role, 100.00);";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Password", PasswordUtility.HashPassword(password));
                command.Parameters.AddWithValue("@Role", role);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateUserByAdmin(int userId, string username, string fullName, string password, string role)
        {
            username = InputValidator.ValidateUsername(username);
            fullName = InputValidator.ValidateFullName(fullName);
            password = InputValidator.ValidatePassword(password);
            role = InputValidator.ValidateRole(role);

            const string sql = @"
UPDATE dbo.Users
SET Username = @Username,
    FullName = @FullName,
    [Password] = @Password,
    [Role] = @Role
WHERE UserId = @UserId;";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Password", PasswordUtility.HashPassword(password));
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static bool UsernameExists(string username, int? excludeUserId)
        {
            const string sql = @"
SELECT COUNT(1)
FROM dbo.Users
WHERE Username = @Username
  AND IsDeleted = 0
  AND (@ExcludeUserId IS NULL OR UserId <> @ExcludeUserId);";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@ExcludeUserId", (object)excludeUserId ?? DBNull.Value);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public static bool DeleteUser(int userId, out string reason)
        {
            reason = string.Empty;

            if (GetRecordCount("SELECT COUNT(1) FROM dbo.MenuItems WHERE ChefUserId = @UserId;", userId) > 0 ||
                GetRecordCount("SELECT COUNT(1) FROM dbo.Orders WHERE CustomerUserId = @UserId OR ChefUserId = @UserId;", userId) > 0 ||
                GetRecordCount("SELECT COUNT(1) FROM dbo.WalletTransactions WHERE CustomerUserId = @UserId;", userId) > 0 ||
                GetRecordCount("SELECT COUNT(1) FROM dbo.Feedbacks WHERE CustomerUserId = @UserId;", userId) > 0)
            {
                ArchiveUser(userId);
                return true;
            }

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Users WHERE UserId = @UserId;", connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }

        private static void ArchiveUser(int userId)
        {
            const string sql = @"
UPDATE dbo.Users
SET Username = CONCAT('arch_', UserId),
    [Password] = CONCAT('ARCHIVED$', UserId),
    IsDeleted = 1
WHERE UserId = @UserId
  AND IsDeleted = 0;";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static User UpdateOwnProfile(int userId, string username, string fullName, string password)
        {
            username = InputValidator.ValidateUsername(username);
            fullName = InputValidator.ValidateFullName(fullName);
            password = InputValidator.ValidatePassword(password);

            const string sql = @"
UPDATE dbo.Users
SET Username = @Username,
    FullName = @FullName,
    [Password] = @Password
WHERE UserId = @UserId;";

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Password", PasswordUtility.HashPassword(password));
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return GetUserById(userId);
        }

        public static List<SalesReportItem> GetSalesReport(int? month, int? year, int? chefUserId, string category)
        {
            if (!string.Equals(category, DomainRules.CategoryAll, StringComparison.OrdinalIgnoreCase))
            {
                category = InputValidator.ValidateCategory(category);
            }

            const string sql = @"
SELECT OrderId, ItemName, Category, ChefName, CustomerName, Price, [Status], OrderDate
FROM dbo.Orders
WHERE (@Month IS NULL OR MONTH(OrderDate) = @Month)
  AND (@Year IS NULL OR YEAR(OrderDate) = @Year)
  AND (@ChefUserId IS NULL OR ChefUserId = @ChefUserId)
  AND (@Category = 'All' OR Category = @Category)
  AND [Status] <> 'Cancelled'
ORDER BY OrderDate DESC;";

            List<SalesReportItem> report = new List<SalesReportItem>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Month", (object)month ?? DBNull.Value);
                command.Parameters.AddWithValue("@Year", (object)year ?? DBNull.Value);
                command.Parameters.AddWithValue("@ChefUserId", (object)chefUserId ?? DBNull.Value);
                command.Parameters.AddWithValue("@Category", category);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        report.Add(new SalesReportItem
                        {
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            ItemName = Convert.ToString(reader["ItemName"]),
                            Category = Convert.ToString(reader["Category"]),
                            ChefName = Convert.ToString(reader["ChefName"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Status = Convert.ToString(reader["Status"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"])
                        });
                    }
                }
            }

            return report;
        }

        public static List<MenuItem> GetMenuForChef(int chefUserId)
        {
            const string sql = @"
SELECT m.MenuItemId, m.ChefUserId, u.FullName AS ChefName, m.Name, m.Category, m.Price, m.IsAvailable
FROM dbo.MenuItems m
INNER JOIN dbo.Users u ON m.ChefUserId = u.UserId
WHERE m.ChefUserId = @ChefUserId
ORDER BY m.Name;";

            return GetMenuItems(sql, new SqlParameter("@ChefUserId", chefUserId));
        }

        public static List<MenuItem> GetAvailableMenu()
        {
            const string sql = @"
SELECT m.MenuItemId, m.ChefUserId, u.FullName AS ChefName, m.Name, m.Category, m.Price, m.IsAvailable
FROM dbo.MenuItems m
INNER JOIN dbo.Users u ON m.ChefUserId = u.UserId
WHERE m.IsAvailable = 1
ORDER BY m.Category, m.Name;";

            return GetMenuItems(sql);
        }

        public static void AddMenuItem(int chefUserId, string name, string category, decimal price, bool isAvailable)
        {
            name = InputValidator.ValidateMenuItemName(name);
            category = InputValidator.ValidateCategory(category);
            price = InputValidator.ValidatePositiveAmount("Price", price);

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
INSERT INTO dbo.MenuItems (ChefUserId, [Name], Category, Price, IsAvailable)
VALUES (@ChefUserId, @Name, @Category, @Price, @IsAvailable);", connection))
            {
                command.Parameters.AddWithValue("@ChefUserId", chefUserId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@IsAvailable", isAvailable);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateMenuItem(int menuItemId, int chefUserId, string name, string category, decimal price, bool isAvailable)
        {
            name = InputValidator.ValidateMenuItemName(name);
            category = InputValidator.ValidateCategory(category);
            price = InputValidator.ValidatePositiveAmount("Price", price);

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
UPDATE dbo.MenuItems
SET [Name] = @Name,
    Category = @Category,
    Price = @Price,
    IsAvailable = @IsAvailable
WHERE MenuItemId = @MenuItemId
  AND ChefUserId = @ChefUserId;", connection))
            {
                command.Parameters.AddWithValue("@MenuItemId", menuItemId);
                command.Parameters.AddWithValue("@ChefUserId", chefUserId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@IsAvailable", isAvailable);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteMenuItem(int menuItemId, int chefUserId)
        {
            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
DELETE FROM dbo.MenuItems
WHERE MenuItemId = @MenuItemId
  AND ChefUserId = @ChefUserId;", connection))
            {
                command.Parameters.AddWithValue("@MenuItemId", menuItemId);
                command.Parameters.AddWithValue("@ChefUserId", chefUserId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static List<Order> GetOrdersForChef(int chefUserId)
        {
            return GetOrders(@"
SELECT OrderId, CustomerUserId, ChefUserId, CustomerName, ChefName, ItemName, Category, Price, [Status], OrderDate
FROM dbo.Orders
WHERE ChefUserId = @ChefUserId
ORDER BY OrderDate DESC;", new SqlParameter("@ChefUserId", chefUserId));
        }

        public static List<Order> GetOrdersForCustomer(int customerUserId)
        {
            return GetOrders(@"
SELECT OrderId, CustomerUserId, ChefUserId, CustomerName, ChefName, ItemName, Category, Price, [Status], OrderDate
FROM dbo.Orders
WHERE CustomerUserId = @CustomerUserId
ORDER BY OrderDate DESC;", new SqlParameter("@CustomerUserId", customerUserId));
        }

        public static void UpdateOrderStatus(int orderId, int chefUserId, string currentStatus, string newStatus)
        {
            if (!DomainRules.ContainsIgnoreCase(DomainRules.OrderStatuses, currentStatus) ||
                !DomainRules.ContainsIgnoreCase(DomainRules.OrderStatuses, newStatus))
            {
                throw new InvalidOperationException("A valid order status is required.");
            }

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
UPDATE dbo.Orders
SET [Status] = @NewStatus
WHERE OrderId = @OrderId
  AND ChefUserId = @ChefUserId
  AND [Status] = @CurrentStatus;", connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@ChefUserId", chefUserId);
                command.Parameters.AddWithValue("@CurrentStatus", currentStatus);
                command.Parameters.AddWithValue("@NewStatus", newStatus);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void PlaceOrder(int customerUserId, int menuItemId)
        {
            const string menuSql = @"
SELECT m.MenuItemId, m.ChefUserId, u.FullName AS ChefName, m.Name, m.Category, m.Price, m.IsAvailable
FROM dbo.MenuItems m
INNER JOIN dbo.Users u ON m.ChefUserId = u.UserId
WHERE m.MenuItemId = @MenuItemId;";

            const string customerSql = @"
SELECT UserId, Username, FullName, [Password], [Role], WalletBalance
FROM dbo.Users
WHERE UserId = @UserId;";

            using (SqlConnection connection = Database.CreateConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        MenuItem menuItem;
                        User customer;

                        using (SqlCommand menuCommand = new SqlCommand(menuSql, connection, transaction))
                        {
                            menuCommand.Parameters.AddWithValue("@MenuItemId", menuItemId);
                            using (SqlDataReader reader = menuCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new InvalidOperationException("The selected menu item no longer exists.");
                                }

                                menuItem = MapMenuItem(reader);
                            }
                        }

                        if (!menuItem.IsAvailable)
                        {
                            throw new InvalidOperationException("The selected menu item is currently unavailable.");
                        }

                        using (SqlCommand customerCommand = new SqlCommand(customerSql, connection, transaction))
                        {
                            customerCommand.Parameters.AddWithValue("@UserId", customerUserId);
                            using (SqlDataReader reader = customerCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new InvalidOperationException("Customer account could not be found.");
                                }

                                customer = MapUser(reader);
                            }
                        }

                        if (customer.WalletBalance < menuItem.Price)
                        {
                            throw new InvalidOperationException("There is not enough balance in the e-wallet.");
                        }

                        using (SqlCommand updateWalletCommand = new SqlCommand(
                            "UPDATE dbo.Users SET WalletBalance = WalletBalance - @Amount WHERE UserId = @UserId;",
                            connection,
                            transaction))
                        {
                            updateWalletCommand.Parameters.AddWithValue("@Amount", menuItem.Price);
                            updateWalletCommand.Parameters.AddWithValue("@UserId", customerUserId);
                            updateWalletCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand walletCommand = new SqlCommand(@"
INSERT INTO dbo.WalletTransactions (CustomerUserId, CustomerName, Amount, [Type], TransactionDate)
VALUES (@CustomerUserId, @CustomerName, @Amount, @Type, GETDATE());", connection, transaction))
                        {
                            walletCommand.Parameters.AddWithValue("@CustomerUserId", customerUserId);
                            walletCommand.Parameters.AddWithValue("@CustomerName", customer.FullName);
                            walletCommand.Parameters.AddWithValue("@Amount", menuItem.Price);
                            walletCommand.Parameters.AddWithValue("@Type", DomainRules.WalletTypePayment);
                            walletCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand orderCommand = new SqlCommand(@"
INSERT INTO dbo.Orders (CustomerUserId, ChefUserId, CustomerName, ChefName, ItemName, Category, Price, [Status], OrderDate)
VALUES (@CustomerUserId, @ChefUserId, @CustomerName, @ChefName, @ItemName, @Category, @Price, @Status, GETDATE());", connection, transaction))
                        {
                            orderCommand.Parameters.AddWithValue("@CustomerUserId", customerUserId);
                            orderCommand.Parameters.AddWithValue("@ChefUserId", menuItem.ChefUserId);
                            orderCommand.Parameters.AddWithValue("@CustomerName", customer.FullName);
                            orderCommand.Parameters.AddWithValue("@ChefName", menuItem.ChefName);
                            orderCommand.Parameters.AddWithValue("@ItemName", menuItem.Name);
                            orderCommand.Parameters.AddWithValue("@Category", menuItem.Category);
                            orderCommand.Parameters.AddWithValue("@Price", menuItem.Price);
                            orderCommand.Parameters.AddWithValue("@Status", DomainRules.OrderStatusPending);
                            orderCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void CancelOrder(int orderId, int customerUserId)
        {
            using (SqlConnection connection = Database.CreateConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Order order = null;

                        using (SqlCommand orderCommand = new SqlCommand(@"
SELECT OrderId, CustomerUserId, ChefUserId, CustomerName, ChefName, ItemName, Category, Price, [Status], OrderDate
FROM dbo.Orders
WHERE OrderId = @OrderId
  AND CustomerUserId = @CustomerUserId;", connection, transaction))
                        {
                            orderCommand.Parameters.AddWithValue("@OrderId", orderId);
                            orderCommand.Parameters.AddWithValue("@CustomerUserId", customerUserId);
                            using (SqlDataReader reader = orderCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    order = MapOrder(reader);
                                }
                            }
                        }

                        if (order == null)
                        {
                            throw new InvalidOperationException("The selected order could not be found.");
                        }

                        if (!string.Equals(order.Status, DomainRules.OrderStatusPending, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new InvalidOperationException("Only pending orders can be cancelled.");
                        }

                        using (SqlCommand updateOrderCommand = new SqlCommand(
                            "UPDATE dbo.Orders SET [Status] = @Status WHERE OrderId = @OrderId;",
                            connection,
                            transaction))
                        {
                            updateOrderCommand.Parameters.AddWithValue("@OrderId", orderId);
                            updateOrderCommand.Parameters.AddWithValue("@Status", DomainRules.OrderStatusCancelled);
                            updateOrderCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand walletCommand = new SqlCommand(
                            "UPDATE dbo.Users SET WalletBalance = WalletBalance + @Amount WHERE UserId = @UserId;",
                            connection,
                            transaction))
                        {
                            walletCommand.Parameters.AddWithValue("@Amount", order.Price);
                            walletCommand.Parameters.AddWithValue("@UserId", customerUserId);
                            walletCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand refundCommand = new SqlCommand(@"
INSERT INTO dbo.WalletTransactions (CustomerUserId, CustomerName, Amount, [Type], TransactionDate)
SELECT UserId, FullName, @Amount, @Type, GETDATE()
FROM dbo.Users
WHERE UserId = @UserId;", connection, transaction))
                        {
                            refundCommand.Parameters.AddWithValue("@Amount", order.Price);
                            refundCommand.Parameters.AddWithValue("@Type", DomainRules.WalletTypeRefund);
                            refundCommand.Parameters.AddWithValue("@UserId", customerUserId);
                            refundCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void TopUpWallet(int customerUserId, decimal amount)
        {
            amount = InputValidator.ValidatePositiveAmount("Top-up amount", amount);

            using (SqlConnection connection = Database.CreateConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand updateWalletCommand = new SqlCommand(
                            "UPDATE dbo.Users SET WalletBalance = WalletBalance + @Amount WHERE UserId = @UserId;",
                            connection,
                            transaction))
                        {
                            updateWalletCommand.Parameters.AddWithValue("@Amount", amount);
                            updateWalletCommand.Parameters.AddWithValue("@UserId", customerUserId);
                            updateWalletCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand walletTransactionCommand = new SqlCommand(@"
INSERT INTO dbo.WalletTransactions (CustomerUserId, CustomerName, Amount, [Type], TransactionDate)
SELECT UserId, FullName, @Amount, @Type, GETDATE()
FROM dbo.Users
WHERE UserId = @UserId;", connection, transaction))
                        {
                            walletTransactionCommand.Parameters.AddWithValue("@Amount", amount);
                            walletTransactionCommand.Parameters.AddWithValue("@Type", DomainRules.WalletTypeTopUp);
                            walletTransactionCommand.Parameters.AddWithValue("@UserId", customerUserId);
                            walletTransactionCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static List<WalletTransaction> GetWalletTransactions(int? customerUserId, int month, int year)
        {
            const string sql = @"
SELECT TransactionId, CustomerUserId, CustomerName, Amount, [Type], TransactionDate
FROM dbo.WalletTransactions
WHERE MONTH(TransactionDate) = @Month
  AND YEAR(TransactionDate) = @Year
  AND (@CustomerUserId IS NULL OR CustomerUserId = @CustomerUserId)
ORDER BY TransactionDate DESC;";

            List<WalletTransaction> transactions = new List<WalletTransaction>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@CustomerUserId", (object)customerUserId ?? DBNull.Value);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new WalletTransaction
                        {
                            TransactionId = Convert.ToInt32(reader["TransactionId"]),
                            CustomerUserId = Convert.ToInt32(reader["CustomerUserId"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            Type = Convert.ToString(reader["Type"]),
                            TransactionDate = Convert.ToDateTime(reader["TransactionDate"])
                        });
                    }
                }
            }

            return transactions;
        }

        public static List<Feedback> GetAllFeedback()
        {
            return GetFeedback(@"
SELECT FeedbackId, OrderId, CustomerUserId, CustomerName, ItemName, Message, Reply, FeedbackDate, ReplyDate
FROM dbo.Feedbacks
ORDER BY FeedbackDate DESC;");
        }

        public static List<Feedback> GetFeedbackByCustomer(int customerUserId)
        {
            return GetFeedback(@"
SELECT FeedbackId, OrderId, CustomerUserId, CustomerName, ItemName, Message, Reply, FeedbackDate, ReplyDate
FROM dbo.Feedbacks
WHERE CustomerUserId = @CustomerUserId
ORDER BY FeedbackDate DESC;", new SqlParameter("@CustomerUserId", customerUserId));
        }

        public static void AddFeedback(int orderId, int customerUserId, string message)
        {
            message = InputValidator.ValidateFeedbackMessage(message, "Feedback");

            using (SqlConnection connection = Database.CreateConnection())
            {
                connection.Open();

                using (SqlCommand orderCheckCommand = new SqlCommand(@"
SELECT COUNT(1)
FROM dbo.Orders
WHERE OrderId = @OrderId
  AND CustomerUserId = @CustomerUserId
  AND [Status] = @Status;", connection))
                {
                    orderCheckCommand.Parameters.AddWithValue("@OrderId", orderId);
                    orderCheckCommand.Parameters.AddWithValue("@CustomerUserId", customerUserId);
                    orderCheckCommand.Parameters.AddWithValue("@Status", DomainRules.OrderStatusCompleted);
                    if (Convert.ToInt32(orderCheckCommand.ExecuteScalar()) == 0)
                    {
                        throw new InvalidOperationException("Feedback can only be sent for your completed orders.");
                    }
                }

                using (SqlCommand existsCommand = new SqlCommand(
                    "SELECT COUNT(1) FROM dbo.Feedbacks WHERE OrderId = @OrderId;",
                    connection))
                {
                    existsCommand.Parameters.AddWithValue("@OrderId", orderId);
                    if (Convert.ToInt32(existsCommand.ExecuteScalar()) > 0)
                    {
                        throw new InvalidOperationException("Feedback has already been submitted for this order.");
                    }
                }

                using (SqlCommand command = new SqlCommand(@"
INSERT INTO dbo.Feedbacks (OrderId, CustomerUserId, CustomerName, ItemName, Message, Reply, FeedbackDate)
SELECT o.OrderId, o.CustomerUserId, o.CustomerName, o.ItemName, @Message, NULL, GETDATE()
FROM dbo.Orders o
WHERE o.OrderId = @OrderId;", connection))
                {
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ReplyToFeedback(int feedbackId, string reply)
        {
            reply = InputValidator.ValidateFeedbackMessage(reply, "Reply");

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
UPDATE dbo.Feedbacks
SET Reply = @Reply,
    ReplyDate = GETDATE()
WHERE FeedbackId = @FeedbackId;", connection))
            {
                command.Parameters.AddWithValue("@Reply", reply);
                command.Parameters.AddWithValue("@FeedbackId", feedbackId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static List<MenuItem> GetMenuItems(string sql, params SqlParameter[] parameters)
        {
            List<MenuItem> items = new List<MenuItem>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(MapMenuItem(reader));
                    }
                }
            }

            return items;
        }

        private static List<Order> GetOrders(string sql, params SqlParameter[] parameters)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(MapOrder(reader));
                    }
                }
            }

            return orders;
        }

        private static List<Feedback> GetFeedback(string sql, params SqlParameter[] parameters)
        {
            List<Feedback> feedbacks = new List<Feedback>();

            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        feedbacks.Add(MapFeedback(reader));
                    }
                }
            }

            return feedbacks;
        }

        private static int GetRecordCount(string sql, int userId)
        {
            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private static void UpdateStoredPassword(int userId, string hashedPassword)
        {
            using (SqlConnection connection = Database.CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "UPDATE dbo.Users SET [Password] = @Password WHERE UserId = @UserId;",
                connection))
            {
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static User MapUser(SqlDataReader reader)
        {
            return new User
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                Username = Convert.ToString(reader["Username"]),
                FullName = Convert.ToString(reader["FullName"]),
                Password = string.Empty,
                Role = Convert.ToString(reader["Role"]),
                WalletBalance = Convert.ToDecimal(reader["WalletBalance"])
            };
        }

        private static MenuItem MapMenuItem(SqlDataReader reader)
        {
            return new MenuItem
            {
                MenuItemId = Convert.ToInt32(reader["MenuItemId"]),
                ChefUserId = Convert.ToInt32(reader["ChefUserId"]),
                ChefName = Convert.ToString(reader["ChefName"]),
                Name = Convert.ToString(reader["Name"]),
                Category = Convert.ToString(reader["Category"]),
                Price = Convert.ToDecimal(reader["Price"]),
                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
            };
        }

        private static Order MapOrder(SqlDataReader reader)
        {
            return new Order
            {
                OrderId = Convert.ToInt32(reader["OrderId"]),
                CustomerUserId = Convert.ToInt32(reader["CustomerUserId"]),
                ChefUserId = Convert.ToInt32(reader["ChefUserId"]),
                CustomerName = Convert.ToString(reader["CustomerName"]),
                ChefName = Convert.ToString(reader["ChefName"]),
                ItemName = Convert.ToString(reader["ItemName"]),
                Category = Convert.ToString(reader["Category"]),
                Price = Convert.ToDecimal(reader["Price"]),
                Status = Convert.ToString(reader["Status"]),
                OrderDate = Convert.ToDateTime(reader["OrderDate"])
            };
        }

        private static Feedback MapFeedback(SqlDataReader reader)
        {
            return new Feedback
            {
                FeedbackId = Convert.ToInt32(reader["FeedbackId"]),
                OrderId = Convert.ToInt32(reader["OrderId"]),
                CustomerUserId = Convert.ToInt32(reader["CustomerUserId"]),
                CustomerName = Convert.ToString(reader["CustomerName"]),
                ItemName = Convert.ToString(reader["ItemName"]),
                Message = Convert.ToString(reader["Message"]),
                Reply = reader["Reply"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Reply"]),
                FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"]),
                ReplyDate = reader["ReplyDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ReplyDate"])
            };
        }
    }
}
