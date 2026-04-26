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
        WalletBalance DECIMAL(10,2) NOT NULL DEFAULT(100.00)
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
