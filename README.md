# BookNest - Library Management System

**BookNest** is a library management system built using **ASP.NET Core MVC**. The system supports two types of users: **Librarians** and **Customers**, each having different features. Librarians can manage books, issue and return them, while customers can view books and their borrowing history.

---

## Features

### Common Features
- **Authentication**: Both customers and librarians can log in to access their respective features.

### Customer Features
- **View Available Books**: Customers can view a list of books available for borrowing.
- **Borrowing History**: Customers can view their borrowing history and see due dates.

### Librarian Features
- **Manage Books**: Librarians can add, edit, and manage the library’s collection of books.
- **Issue and Return Books**: Librarians can issue books to customers and record book returns.
- **View Customer Borrowing History**: Librarians can view the borrowing history of any customer.
- **View Issued Books**: See all books that are currently issued and not yet returned.

---

## Prerequisites

Before you begin, ensure that you have the following installed:

- **.NET 8 SDK or later**: You can download it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- **SQL Server**: A local or remote SQL Server instance for the database.
- **Entity Framework Core CLI Tools**: Used for running migrations and updating the database schema.

To install **EF Core CLI tools** globally, run:

```bash
dotnet tool install --global dotnet-ef
```
You also need to install these nuget packages, you can do this from Nuget package manager console, just run the following commands:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
After installing these packages, restore all dependencies:
```bash
dotnet restore
```

## Database Configuration
Change the ConnectionString in appsettings.json according to your database:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=BookNestDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
Apply Migrations and Update Database from Package Manager Console:
```bash
Add-Migration [Migration Name]
Update-Database
```
Finally, Build and run the project:
```bash
dotnet build
dotnet run
```

