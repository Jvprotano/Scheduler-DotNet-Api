# Agende Backend (Scheduling API)

This repository contains the backend API for Agende — a scheduling and appointment management system built with .NET 8.

Summary
- Tech stack: .NET 8, ASP.NET Core Web API, Entity Framework Core (Npgsql/Postgres), JWT Authentication, Swagger/OpenAPI, AutoMapper, ApplicationInsights (optional)
- Purpose: expose endpoints to register businesses, manage services and employees, and schedule appointments between clients and businesses.

Repository layout (top-level)
- `Agende.sln` — Visual Studio solution file
- `Dockerfile`, `docker-compose.yml` — container related files
- `README.md` — this file
- `PROJECT_CONTEXT.md` — machine-readable project context for AI tools (created alongside this README)
- `src/` — source projects

Key projects under `src/`
- `Agende.Api/` — ASP.NET Core Web API project serving the HTTP endpoints
  - `Program.cs` — application startup, DI, authentication and Swagger configuration
  - `appsettings.json`, `appsettings.Development.json` — configuration
  - `Controllers/` — API controllers organized by version (e.g. `V1`)
  - `Configuration/` — AutoMapper profiles, Swagger configuration
  - `DTOs/` — request/response DTOs
  - `Validators/` — FluentValidation validators for DTOs
- `Agende.Business/` — business logic layer containing services, interfaces, models and enums
  - `Services/` — implementations (AuthService, CompanyService, SchedulingService, UserService)
  - `Interfaces/` — service, repository and http client interfaces
  - `Models/` — domain models including `ApplicationUser`, `Company`, `Scheduling`, etc.
- `Agende.Tests/` — unit/integration tests (project structure present)

Getting started (developer)
1. Requirements
   - .NET 8 SDK
   - PostgreSQL (or compatible) for local development (connection string uses `DefaultConnection`)

2. Restore and build
   - Open a terminal in the repo root and run:

     dotnet restore
     dotnet build

3. Configure the database and secrets
   - Update `src/Agende.Api/appsettings.Development.json` (or environment variables) with:
     - `ConnectionStrings:DefaultConnection` — PostgreSQL connection string
     - `Jwt:Key` and `Jwt:Issuer` — JWT signing key and issuer
     - `APPLICATIONINSIGHTS_CONNECTION_STRING` (optional) — App Insights connection string

4. Run locally
   - From repo root or the `src/Agende.Api` folder:

     dotnet run --project src/Agende.Api/Agende.Api.csproj

   - The API hosts Swagger UI at `/swagger` by default. When running in development the app will use HTTPS endpoints.

Database migrations
- This project uses EF Core. If migrations exist, apply them with:

  dotnet ef database update --project src/Agende.Api/Agende.Api.csproj

Authentication & Authorization
- JWT Bearer authentication is configured in `Program.cs` and uses the `Jwt:Key` configuration value as the symmetric signing key.
- Identity endpoints are enabled with `AddIdentityApiEndpoints<ApplicationUser>()` and EF stores configured with `ApplicationDbContext`.

Swagger / API versioning
- API Versioning is enabled and Swagger is configured to expose multiple API versions. See `Configuration/Swagger` for details.

Useful commands (VS Code / terminal)
- Build: dotnet build
- Run: dotnet run --project src/Agende.Api/Agende.Api.csproj
- Tests: dotnet test

Where to look next
- `src/Agende.Api/Controllers/V1` — public endpoints and route patterns
- `src/Agende.Business/Services` — business logic implementations
- `src/Agende.Business/Models` — primary domain models

Contributing
- Please open issues or pull requests. Follow the existing style and unit test any business logic changes.

License
- See `LICENSE` if present in the repository root.

--
This README focuses on developer onboarding. A detailed machine-readable project context file (`PROJECT_CONTEXT.md`) is available in the repository and intended for use by AI tooling.

# Scheduling API

This project is a comprehensive scheduling API developed using .NET 8. It serves as the backend for a robust appointment management application. The API allows users to register their businesses and services, making them available for clients to book. Additionally, users can schedule services with other businesses.

## Key Features

- Business and service registration
- Appointment scheduling and management
- User authentication and authorization
- Real-time notifications for appointments
- Integration with third-party services for enhanced functionality

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another supported database

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/scheduling-api.git
   cd scheduling-api
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Update the database connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
     }
   }
   ```

4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

### Running the Application

To run the application locally, use the following command:
```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`.


## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
