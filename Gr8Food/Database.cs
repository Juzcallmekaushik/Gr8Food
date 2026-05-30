using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class Database
    {
        private readonly string _masterConnectionString =
            ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;

        private readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["Gr8FoodConnection"].ConnectionString;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public void InitializeDatabase()
        {
            CreateDatabaseIfNeeded();
            CreateTablesIfNeeded();
            ApplySchemaUpgrades();
            SeedDataIfNeeded();
            UpgradePlaintextPasswords();
        }

        private void CreateDatabaseIfNeeded()
        {
            const string sql = @"
                IF DB_ID('Gr8FoodDb') IS NULL
                BEGIN
                    CREATE DATABASE Gr8FoodDb;
                END";

            using (SqlConnection connection = new SqlConnection(_masterConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CreateTablesIfNeeded()
        {
            const string sql = @"
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        UserId INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        FullName NVARCHAR(100) NOT NULL,
        [Password] NVARCHAR(50) NOT NULL,
        [Role] NVARCHAR(20) NOT NULL,
        WalletBalance DECIMAL(10,2) NOT NULL DEFAULT(100.00),
        IsDeleted BIT NOT NULL DEFAULT(0)
    );
END;

IF OBJECT_ID('dbo.MenuItems', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.MenuItems
    (
        MenuItemId INT IDENTITY(1,1) PRIMARY KEY,
        ChefUserId INT NOT NULL,
        [Name] NVARCHAR(100) NOT NULL,
        Category NVARCHAR(50) NOT NULL,
        Price DECIMAL(10,2) NOT NULL,
        IsAvailable BIT NOT NULL DEFAULT(1),
        CONSTRAINT FK_MenuItems_Users FOREIGN KEY (ChefUserId) REFERENCES dbo.Users(UserId)
    );
END;

IF OBJECT_ID('dbo.Orders', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Orders
    (
        OrderId INT IDENTITY(1,1) PRIMARY KEY,
        CustomerUserId INT NOT NULL,
        ChefUserId INT NOT NULL,
        CustomerName NVARCHAR(100) NOT NULL,
        ChefName NVARCHAR(100) NOT NULL,
        ItemName NVARCHAR(100) NOT NULL,
        Category NVARCHAR(50) NOT NULL,
        Price DECIMAL(10,2) NOT NULL,
        [Status] NVARCHAR(20) NOT NULL,
        OrderDate DATETIME NOT NULL DEFAULT(GETDATE()),
        CONSTRAINT FK_Orders_Customer FOREIGN KEY (CustomerUserId) REFERENCES dbo.Users(UserId),
        CONSTRAINT FK_Orders_Chef FOREIGN KEY (ChefUserId) REFERENCES dbo.Users(UserId)
    );
END;

IF OBJECT_ID('dbo.WalletTransactions', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.WalletTransactions
    (
        TransactionId INT IDENTITY(1,1) PRIMARY KEY,
        CustomerUserId INT NOT NULL,
        CustomerName NVARCHAR(100) NOT NULL,
        Amount DECIMAL(10,2) NOT NULL,
        [Type] NVARCHAR(20) NOT NULL,
        TransactionDate DATETIME NOT NULL DEFAULT(GETDATE()),
        CONSTRAINT FK_WalletTransactions_Users FOREIGN KEY (CustomerUserId) REFERENCES dbo.Users(UserId)
    );
END;

IF OBJECT_ID('dbo.Feedbacks', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Feedbacks
    (
        FeedbackId INT IDENTITY(1,1) PRIMARY KEY,
        OrderId INT NOT NULL,
        CustomerUserId INT NOT NULL,
        CustomerName NVARCHAR(100) NOT NULL,
        ItemName NVARCHAR(100) NOT NULL,
        Message NVARCHAR(500) NOT NULL,
        Reply NVARCHAR(500) NULL,
        FeedbackDate DATETIME NOT NULL DEFAULT(GETDATE()),
        ReplyDate DATETIME NULL,
        CONSTRAINT FK_Feedbacks_Orders FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId),
        CONSTRAINT FK_Feedbacks_Users FOREIGN KEY (CustomerUserId) REFERENCES dbo.Users(UserId)
    );
END;";

            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void ApplySchemaUpgrades()
        {
            string sql = string.Format(@"
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Users_Role')
BEGIN
    ALTER TABLE dbo.Users
    ADD CONSTRAINT CK_Users_Role CHECK ([Role] IN ('{0}', '{1}', '{2}', '{3}'));
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Users_WalletBalance')
BEGIN
    ALTER TABLE dbo.Users
    ADD CONSTRAINT CK_Users_WalletBalance CHECK (WalletBalance >= 0);
END;

IF COL_LENGTH('dbo.Users', 'IsDeleted') IS NULL
BEGIN
    ALTER TABLE dbo.Users
    ADD IsDeleted BIT NOT NULL CONSTRAINT DF_Users_IsDeleted DEFAULT(0);
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_MenuItems_Category')
BEGIN
    ALTER TABLE dbo.MenuItems
    ADD CONSTRAINT CK_MenuItems_Category CHECK (Category IN ('{4}', '{5}', '{6}', '{7}', '{8}'));
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_MenuItems_Price')
BEGIN
    ALTER TABLE dbo.MenuItems
    ADD CONSTRAINT CK_MenuItems_Price CHECK (Price > 0);
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_MenuItems_Name')
BEGIN
    ALTER TABLE dbo.MenuItems
    ADD CONSTRAINT CK_MenuItems_Name CHECK (LEN(LTRIM(RTRIM([Name]))) > 0);
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Orders_Status')
BEGIN
    ALTER TABLE dbo.Orders
    ADD CONSTRAINT CK_Orders_Status CHECK ([Status] IN ('{9}', '{10}', '{11}', '{12}'));
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Orders_Category')
BEGIN
    ALTER TABLE dbo.Orders
    ADD CONSTRAINT CK_Orders_Category CHECK (Category IN ('{4}', '{5}', '{6}', '{7}', '{8}'));
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Orders_Price')
BEGIN
    ALTER TABLE dbo.Orders
    ADD CONSTRAINT CK_Orders_Price CHECK (Price > 0);
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_WalletTransactions_Amount')
BEGIN
    ALTER TABLE dbo.WalletTransactions
    ADD CONSTRAINT CK_WalletTransactions_Amount CHECK (Amount > 0);
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_WalletTransactions_Type')
BEGIN
    ALTER TABLE dbo.WalletTransactions
    ADD CONSTRAINT CK_WalletTransactions_Type CHECK ([Type] IN ('{13}', '{14}', '{15}'));
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Feedbacks_Message')
BEGIN
    ALTER TABLE dbo.Feedbacks
    ADD CONSTRAINT CK_Feedbacks_Message CHECK (LEN(LTRIM(RTRIM([Message]))) > 0);
END;

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Feedbacks_Reply')
BEGIN
    ALTER TABLE dbo.Feedbacks
    ADD CONSTRAINT CK_Feedbacks_Reply CHECK ([Reply] IS NULL OR LEN(LTRIM(RTRIM([Reply]))) > 0);
END;",
                DomainRules.RoleAdmin,
                DomainRules.RoleManager,
                DomainRules.RoleChef,
                DomainRules.RoleCustomer,
                DomainRules.CategoryBreakfast,
                DomainRules.CategoryLunch,
                DomainRules.CategoryDinner,
                DomainRules.CategorySnacks,
                DomainRules.CategoryDrinks,
                DomainRules.OrderStatusPending,
                DomainRules.OrderStatusInProgress,
                DomainRules.OrderStatusCompleted,
                DomainRules.OrderStatusCancelled,
                DomainRules.WalletTypeTopUp,
                DomainRules.WalletTypePayment,
                DomainRules.WalletTypeRefund);

            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void SeedDataIfNeeded()
        {
            const string sql = @"
DECLARE @DefaultPassword NVARCHAR(50) = '123';

UPDATE dbo.Users
SET Username = CONCAT('legacy_', UserId, '_', Username),
    IsDeleted = 1
WHERE Username IN ('manager', 'chef', 'cust1', 'cust2', 'cust3')
  AND IsDeleted = 0;

UPDATE dbo.MenuItems
SET IsAvailable = 0
WHERE ChefUserId IN (SELECT UserId FROM dbo.Users WHERE IsDeleted = 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('admin', 'Admin', @DefaultPassword, 'Admin', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'kaushik')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('kaushik', 'Kaushik', @DefaultPassword, 'Admin', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'shaib')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('shaib', 'Shaib', @DefaultPassword, 'Chef', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'hussain')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('hussain', 'Hussain', @DefaultPassword, 'Chef', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'saiyam')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('saiyam', 'Saiyam', @DefaultPassword, 'Manager', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'tom')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('tom', 'Tom', @DefaultPassword, 'Manager', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'leong')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('leong', 'Leong', @DefaultPassword, 'Customer', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'aisha')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('aisha', 'Aisha Tan', @DefaultPassword, 'Customer', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'daniel')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('daniel', 'Daniel Wong', @DefaultPassword, 'Customer', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'priya')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('priya', 'Priya Nair', @DefaultPassword, 'Customer', 100.00);
END;

DECLARE @ShaibId INT = (SELECT UserId FROM dbo.Users WHERE Username = 'shaib' AND IsDeleted = 0);
DECLARE @HussainId INT = (SELECT UserId FROM dbo.Users WHERE Username = 'hussain' AND IsDeleted = 0);

IF NOT EXISTS (SELECT 1 FROM dbo.MenuItems WHERE ChefUserId = @ShaibId AND [Name] = 'Nasi Lemak')
BEGIN
    INSERT INTO dbo.MenuItems (ChefUserId, [Name], Category, Price, IsAvailable)
    VALUES
        (@ShaibId, 'Nasi Lemak', 'Breakfast', 5.00, 1),
        (@ShaibId, 'Roti Canai', 'Breakfast', 1.50, 1),
        (@ShaibId, 'Iced Lemon Tea', 'Drinks', 3.50, 1),
        (@ShaibId, 'Milo Ais', 'Drinks', 3.40, 1);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.MenuItems WHERE ChefUserId = @HussainId AND [Name] = 'Club Sandwich')
BEGIN
    INSERT INTO dbo.MenuItems (ChefUserId, [Name], Category, Price, IsAvailable)
    VALUES
        (@HussainId, 'Club Sandwich', 'Lunch', 12.50, 1),
        (@HussainId, 'French Fries', 'Snacks', 6.50, 1),
        (@HussainId, 'Chicken Nuggets', 'Snacks', 9.00, 1),
        (@HussainId, 'Chicken Rice', 'Lunch', 10.00, 1);


END;";

            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void UpgradePlaintextPasswords()
        {
            const string selectSql = @"
SELECT UserId, [Password]
FROM dbo.Users
WHERE IsDeleted = 0;";

            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(selectSql, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    System.Collections.Generic.List<System.Tuple<int, string>> updates =
                        new System.Collections.Generic.List<System.Tuple<int, string>>();

                    while (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["UserId"]);
                        string storedPassword = Convert.ToString(reader["Password"]);

                        if (!PasswordUtility.IsHashedPassword(storedPassword))
                        {
                            updates.Add(System.Tuple.Create(userId, PasswordUtility.HashPassword(storedPassword)));
                        }
                    }

                    reader.Close();

                    foreach (System.Tuple<int, string> update in updates)
                    {
                        using (SqlCommand updateCommand = new SqlCommand(
                            "UPDATE dbo.Users SET [Password] = @Password WHERE UserId = @UserId;",
                            connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Password", update.Item2);
                            updateCommand.Parameters.AddWithValue("@UserId", update.Item1);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
