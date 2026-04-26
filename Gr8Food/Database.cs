using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Gr8Food
{
    public static class Database
    {
        private static readonly string MasterConnectionString =
            ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;

        private static readonly string AppConnectionString =
            ConfigurationManager.ConnectionStrings["Gr8FoodConnection"].ConnectionString;

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(AppConnectionString);
        }

        public static void InitializeDatabase()
        {
            CreateDatabaseIfNeeded();
            CreateTablesIfNeeded();
            SeedDataIfNeeded();
        }

        private static void CreateDatabaseIfNeeded()
        {
            const string sql = @"
IF DB_ID('Gr8FoodDb') IS NULL
BEGIN
    CREATE DATABASE Gr8FoodDb;
END";

            using (SqlConnection connection = new SqlConnection(MasterConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void CreateTablesIfNeeded()
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
        WalletBalance DECIMAL(10,2) NOT NULL DEFAULT(100.00)
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

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void SeedDataIfNeeded()
        {
            const string sql = @"
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('admin', 'System Admin', '123', 'Admin', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'manager')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('manager', 'Restaurant Manager', '123', 'Manager', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'chef')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('chef', 'Main Chef', '123', 'Chef', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'cust1')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('cust1', 'Customer One', '123', 'Customer', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'cust2')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('cust2', 'Customer Two', '123', 'Customer', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'cust3')
BEGIN
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('cust3', 'Customer Three', '123', 'Customer', 100.00);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.MenuItems)
BEGIN
    DECLARE @ChefId INT = (SELECT TOP 1 UserId FROM dbo.Users WHERE Username = 'chef');

    INSERT INTO dbo.MenuItems (ChefUserId, [Name], Category, Price, IsAvailable)
    VALUES
        (@ChefId, 'Nasi Lemak', 'Breakfast', 8.50, 1),
        (@ChefId, 'Chicken Chop', 'Dinner', 18.00, 1),
        (@ChefId, 'Club Sandwich', 'Lunch', 12.50, 1),
        (@ChefId, 'French Fries', 'Snacks', 6.50, 1),
        (@ChefId, 'Iced Lemon Tea', 'Drinks', 4.50, 1);
END;";

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
