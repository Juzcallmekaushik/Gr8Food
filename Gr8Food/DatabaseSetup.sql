IF DB_ID('Gr8FoodDb') IS NULL
BEGIN
    CREATE DATABASE Gr8FoodDb;
END;
GO

USE Gr8FoodDb;
GO

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
GO

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
GO

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
GO

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
GO

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
END;
GO

UPDATE dbo.Users
SET Username = CONCAT('legacy_', UserId, '_', Username),
    IsDeleted = 1
WHERE Username IN ('manager', 'chef', 'cust1', 'cust2', 'cust3')
  AND IsDeleted = 0;
GO

UPDATE dbo.MenuItems
SET IsAvailable = 0
WHERE ChefUserId IN (SELECT UserId FROM dbo.Users WHERE IsDeleted = 1);
GO

DECLARE @DefaultPassword NVARCHAR(50) = '123';

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('admin', 'Admin', @DefaultPassword, 'Admin', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'kaushik')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('kaushik', 'Kaushik', @DefaultPassword, 'Admin', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'shaib')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('shaib', 'Shaib', @DefaultPassword, 'Chef', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'hussain')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('hussain', 'Hussain', @DefaultPassword, 'Chef', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'saiyam')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('saiyam', 'Saiyam', @DefaultPassword, 'Manager', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'tom')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('tom', 'Tom', @DefaultPassword, 'Manager', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'leong')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('leong', 'Leong', @DefaultPassword, 'Customer', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'aisha')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('aisha', 'Aisha Tan', @DefaultPassword, 'Customer', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'daniel')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('daniel', 'Daniel Wong', @DefaultPassword, 'Customer', 100.00);

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'priya')
    INSERT INTO dbo.Users (Username, FullName, [Password], [Role], WalletBalance)
    VALUES ('priya', 'Priya Nair', @DefaultPassword, 'Customer', 100.00);

DECLARE @ShaibId INT = (SELECT UserId FROM dbo.Users WHERE Username = 'shaib' AND IsDeleted = 0);
DECLARE @HussainId INT = (SELECT UserId FROM dbo.Users WHERE Username = 'hussain' AND IsDeleted = 0);

IF NOT EXISTS (SELECT 1 FROM dbo.MenuItems WHERE ChefUserId = @ShaibId AND [Name] = 'Nasi Lemak')
BEGIN
    INSERT INTO dbo.MenuItems (ChefUserId, [Name], Category, Price, IsAvailable)
    VALUES
        (@ShaibId, 'Nasi Lemak', 'Breakfast', 8.50, 1),
        (@ShaibId, 'Chicken Chop', 'Dinner', 18.00, 1),
        (@ShaibId, 'Iced Lemon Tea', 'Drinks', 4.50, 1);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.MenuItems WHERE ChefUserId = @HussainId AND [Name] = 'Club Sandwich')
BEGIN
    INSERT INTO dbo.MenuItems (ChefUserId, [Name], Category, Price, IsAvailable)
    VALUES
        (@HussainId, 'Club Sandwich', 'Lunch', 12.50, 1),
        (@HussainId, 'French Fries', 'Snacks', 6.50, 1);
END;
GO
