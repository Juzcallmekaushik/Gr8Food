# Gr8Food Management System

Desktop restaurant management system built with C# WinForms and SQL Server for the CT044-3-1-IOOP assignment.

## Requirements

To run this project, make sure you have:

- Visual Studio with `.NET desktop development`
- .NET Framework `4.8`
- SQL Server LocalDB or SQL Server

This project does not require NuGet package restore.

## How to Open the Project

1. Clone or download this repository.
2. Open Visual Studio.
3. Open the project file:
   - `Gr8Food/Gr8Food.csproj`
4. Build and run the project.

If the `.slnx` file gives trouble on a different machine, open `Gr8Food.csproj` directly instead.

## Database Setup

The application creates the database, tables, and seed data automatically on startup.

Default connection strings are stored in:

- `Gr8Food/App.config`

Current default setup uses:

- `Data Source=(localdb)\MSSQLLocalDB`
- Database name: `Gr8FoodDb`

## If Database Connection Fails

If your machine does not have `MSSQLLocalDB`, update the connection strings in `App.config`.

Example:

```xml
<add name="MasterConnection"
     connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=master;Integrated Security=True;Encrypt=False" />

<add name="Gr8FoodConnection"
     connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=Gr8FoodDb;Integrated Security=True;Encrypt=False" />
```

Replace `YOUR_SERVER_NAME` with your SQL Server instance name.

## Default Login Accounts

The system seeds these accounts automatically:

- Admin
  - Username: `admin`
  - Password: `123`
- Manager
  - Username: `manager`
  - Password: `123`
- Chef
  - Username: `chef`
  - Password: `123`
- Customer
  - Username: `cust1`
  - Password: `123`
- Customer
  - Username: `cust2`
  - Password: `123`
- Customer
  - Username: `cust3`
  - Password: `123`

## Main Features

### Admin

- Add user
- Remove user
- Update any user profile
- View sales report
- Filter sales report by month, year, category, and chef
- Update own profile

### Manager

- View customer feedback
- Reply to customer feedback
- View e-wallet transactions
- Filter wallet transactions by customer and month/year
- Update own profile

### Chef

- Add menu items
- Edit menu items
- Remove menu items
- Set menu availability
- View customer orders
- Update order status
- Update own profile

### Customer

- Browse available menu items
- Place order
- View order status
- Cancel pending order with refund
- Top up e-wallet
- Send feedback after order completion
- Update own profile

## Notes for Group Members

- Make sure your machine can connect to SQL Server before running the system.
- The database is created automatically the first time the app starts.
- If one teammate uses a different SQL Server instance, only `App.config` usually needs to be updated.
- Build the project in Visual Studio before presentation day to make sure your local environment is ready.

## Build

This project was successfully built using the project file:

- `Gr8Food/Gr8Food.csproj`

## Project Structure

- `Gr8Food/` - main WinForms application
- `Gr8Food/AppRepository.cs` - data access and business operations
- `Gr8Food/Database.cs` - database initialization and schema setup
- `Gr8Food/DomainRules.cs` - centralized roles, categories, statuses, and transaction types
- `Gr8Food/InputValidator.cs` - shared validation rules

