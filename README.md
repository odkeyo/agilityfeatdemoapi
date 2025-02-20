<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Agility Feat Demo API - README</title>
    <style>
        body { font-family: Arial, sans-serif; line-height: 1.6; margin: 20px; }
        h1, h2, h3 { color: #333; }
        pre { background: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; }
        ul { padding-left: 20px; }
    </style>
</head>
<body>
    <h1>Agility Feat Demo API</h1>
    <p><strong>Backend for transaction management.</strong> This API provides endpoints for creating, retrieving, and filtering financial transactions.</p>
    
    <h2>Project Structure</h2>
    <pre>
.env
.gitignore
appsettings.Development.json
appsettings.json
Backend.csproj
Backend.http
Backend.sln
database.sqlite
Program.cs
README.md
sqlite3.exe
    </pre>

    <h3>Key Directories:</h3>
    <ul>
        <li><strong>.github/workflows/</strong> - CI/CD configurations.</li>
        <li><strong>Controllers/</strong> - API controllers.</li>
        <li><strong>Core/Interfaces/</strong> - Service interfaces.</li>
        <li><strong>Data/</strong> - Database context and connections.</li>
        <li><strong>Models/</strong> - Entity models.</li>
        <li><strong>Repositories/</strong> - Data repositories.</li>
        <li><strong>Services/</strong> - Business logic services.</li>
        <li><strong>Migrations/</strong> - EF Core database migrations.</li>
        <li><strong>Properties/</strong> - Configuration settings.</li>
    </ul>

    <h2>Setup Instructions</h2>
    <ol>
        <li>Clone the repository: <pre>git clone https://github.com/your-repo/agilityfeatdemoapi.git</pre></li>
        <li>Navigate to the backend directory: <pre>cd Backend</pre></li>
        <li>Run the application: <pre>dotnet run</pre></li>
        <li>Access Swagger UI at: <pre>http://localhost:5000/swagger</pre></li>
    </ol>

    <h2>Challenges Faced</h2>
    <ul>
        <li><strong>SQLite in Azure:</strong> SQLite does not work well in Azure due to its file-based nature. This prevented complete testing of the application in the cloud environment. A migration to a full SQL-based solution (e.g., PostgreSQL, SQL Server) is recommended.</li>
        <li><strong>Handling Date Formats:</strong> Adjusting date formats between backend and frontend to ensure correct rendering and filtering.</li>
        <li><strong>API Response Standardization:</strong> Improved error handling and response consistency for better frontend integration.</li>
    </ul>

    <h2>Learnings</h2>
    <ul>
        <li>Using <strong>Entity Framework Core</strong> with SQLite for rapid prototyping.</li>
        <li>Importance of database compatibility in cloud environments.</li>
        <li>Optimizing API filtering to reduce frontend processing.</li>
    </ul>
</body>
</html>
