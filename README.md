# OrgStructure API

## Setup and Run

1. After clonning navigate to project directory in terminal
2. Restore dependencies:
   ```bash
   dotnet restore
- Database Configuration -
  The API uses local SQL Server with this connection string (can be modified in [appsettings.json]()):
3. Create and update database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
5. Run the API:
    ```bash
    dotnet run

API Documentation
Online: https://registry.scalar.com/@nikitabuinovskyi-gmail-com-team/apis/orgstructureapi/latest

Local Swagger: http://localhost:5000/swagger/

6. Run Tests with [Teapie](https://www.teapie.fun/docs/introduction.html):
    ```bash
    teapie test Tests