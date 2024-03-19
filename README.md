# ADO.NET Employee CRUD Program

## How to Run the Program:
- Clone the Project
- Make Sure to Install SQL Server 2022 and SQL Server Management Studio
- Run the Query in SQL Server Management Studio to create the Database
```csharp
USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'Employee'
)
CREATE DATABASE [Employee]
GO
```
- Then Run the Program in Visual Studio 2022
- Enjoy!
  
Author: Sarthak Roy
