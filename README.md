# Backend - AgilityFeat Demo

## Project Overview
The backend of this project is built with .NET 9 and SQLite as the database. It provides RESTful API endpoints for transaction management.

## Folder Structure
```
/Backend
├── Controllers
│   ├── ApiController.cs
│   ├── TransactionController.cs
├── Core
│   ├── Interfaces
│   │   ├── IConnection.cs
│   │   ├── ITransaction.cs
├── Data
│   ├── AppDbContext.cs
│   ├── Connection.cs
├── Models
│   ├── Transaction.cs
│   ├── TransactionFilter.cs
├── Repositories
│   ├── TransactionRepository.cs
├── Services
│   ├── TransactionService.cs
├── Properties
│   ├── launchSettings.json
├── Program.cs
├── appsettings.json
├── database.sqlite
├── Backend.sln
```

## Setup Instructions
To set up the backend locally, follow these steps:
```
# Clone the repository
git clone https://github.com/your-repo/backend.git

# Navigate to the backend directory
cd backend

# Run the application
dotnet run
```

## Challenges & Learnings
- **SQLite Limitations:** SQLite does not work well in Azure, making it difficult to test the complete application in a production-like environment.
- **Entity Framework Migrations:** Managing database migrations with Entity Framework required careful planning to avoid schema conflicts.
- **API Response Handling:** Implementing proper error handling and structured responses was necessary to ensure a robust API.

## Next Steps
To improve the project further:
- Switch to a more scalable database such as PostgreSQL or SQL Server for production deployment.
- Implement authentication and authorization for secured API access.
- Enhance logging and monitoring capabilities.

## Contributors
Developed by **Diego Cárdenas**
