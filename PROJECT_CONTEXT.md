# PROJECT CONTEXT — Agende Backend (Scheduling API)

Purpose
- Provide a machine-readable, detailed summary of the repository to be consumed by AI tools and new developers. Includes project layout, important files, DI and startup behavior, models, controllers, and useful notes for static analysis or code generation.

Repository root
- `Agende.sln` — solution file
- `Dockerfile`, `docker-compose.yml` — containers (if present)
- `src/Agende.Api/` — main Web API project

Important files (quick map)
- `src/Agende.Api/Program.cs` — application bootstrap. Key behaviors:
  - Adds controllers, configures lowercase routing, CORS policy named `AllowLocalhost` (allows `http://localhost:4200`).
  - Adds AutoMapper, API versioning, ProblemDetails, and Swagger Gen with JWT security definition.
  - Configures JWT bearer authentication; reads `Jwt:Key` and `Jwt:Issuer` from configuration.
  - Enables Identity API endpoints for `ApplicationUser` and configures EF stores for `ApplicationDbContext`.
  - Adds DbContext `ApplicationDbContext` using Npgsql and `DefaultConnection` connection string.
  - Registers repositories via `AddRepositories()` extension method.
  - Enables Application Insights logging using `APPLICATIONINSIGHTS_CONNECTION_STRING`.

- `src/Agende.Api/appsettings.json` and `appsettings.Development.json` — store connection strings and Jwt config.

- `src/Agende.Api/Controllers/` — controllers grouped by version (e.g., `V1`). These define the HTTP routes and map DTOs to domain models.

- `src/Agende.Api/Configuration/Swagger/` — custom Swagger configuration and `ConfigureSwaggerGenOptions` used in `Program.cs`.

- `src/Agende.Business/Models/` — domain models. Notable models:
  - `ApplicationUser` — Identity user model used with AddIdentityApiEndpoints.
  - `Company`, `CompanyEmployee`, `Scheduling`, `CompanyServiceOffered`, `CompanyOpeningHours`, `EmployeeServiceLink` — business domain models.

- `src/Agende.Business/Services/` — core service implementations used by controllers:
  - `AuthService.cs`, `CompanyService.cs`, `SchedulingService.cs`, `UserService.cs`.

- `src/Agende.Business/Interfaces/` — interfaces for repositories, services and http clients.

Dependency injection and service registrations
- Identity endpoints: `builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();`
- Database context: `builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));`
- Repository registration: `builder.Services.AddRepositories();` (extension method — search under `src` for its implementation to see which repositories are added)
- AutoMapper: `builder.Services.AddAutoMapper(typeof(Program));`
- Swagger customization: `IConfigureOptions<SwaggerGenOptions>` implementation `ConfigureSwaggerGenOptions` in `Configuration/Swagger`.

Authentication
- Auth uses JWT Bearer tokens. Token validation parameters in `Program.cs` require `Jwt:Key` for IssuerSigningKey. Issuer/Audience validation are disabled in the current config (ValidateIssuer=false, ValidateAudience=false), but values are still read into `ValidIssuer/ValidAudience`.

Routing & CORS
- Routes are lowercased (RouteOptions LowercaseUrls/LowercaseQueryStrings).
- CORS policy `AllowLocalhost` allows `http://localhost:4200` origins and any header/method.

API Versioning and Swagger
- ApiVersioning is enabled and configured to report versions. Mvc builder adds ApiExplorer options to substitute version in URL and format group names as `'v'VVV`.
- Swagger UI is configured to create an endpoint for each API version; `SwaggerDefaultValues` and `ConfigureSwaggerGenOptions` are used to set default metadata.

Database
- EF Core + Npgsql (Postgres). Connection string key: `DefaultConnection` in configuration.

Tests
- `src/Agende.Tests/` contains test projects (unit and/or integration). Use `dotnet test` to run.

Where to find business logic
- `src/Agende.Business/Services` — contains most business rules. For any data access check the `Repositories` implementations registered by `AddRepositories()`.

Common DTOs and validation
- DTOs are in `src/Agende.Api/DTOs/Request` and `DTOs/Response`. Validators are in `src/Agende.Api/Validators` (FluentValidation usage).

How endpoints are organized (high level)
- Controllers are versioned (e.g., `Controllers/V1`). Typical controller responsibilities:
  - Accept request DTOs
  - Validate via validators
  - Map DTOs to domain models via AutoMapper
  - Call services from `Agende.Business` and return DTO responses or ProblemDetails on errors

Search hints for maintainers or AI tools
- To find repository registration, search for `AddRepositories()` implementation (likely in `Agende.Data` or `Agende.Business` or an extensions class).
- To find `ApplicationDbContext`, search for class named `ApplicationDbContext` under `src`.
- To locate DTOs and controllers, search under `src/Agende.Api/Controllers` and `src/Agende.Api/DTOs`.

Edge cases & notes for code-gen or analysis
- Jwt:Key must be set to run authenticated flows. The code throws if Jwt:Key is null when building the IssuerSigningKey.
- Database migrations and the exact DbContext model need to be read before generating migrations or seed scripts.
- ApplicationInsights is optional; missing connection string should not prevent local development unless the logger relies on it.

Minimal quick commands for CI or dev
- Restore: dotnet restore
- Build: dotnet build
- Run API: dotnet run --project src/Agende.Api/Agende.Api.csproj
- Tests: dotnet test

Contact points
- Look in `src/Agende.Api/Controllers` for public endpoints.
- Look in `src/Agende.Business/Services` for business logic implementations.

Small checklist for future automation (recommended)
1. Add a CONTRIBUTING.md with branch and commit conventions.
2. Add GitHub Actions workflow for build/test/publish.
3. Add a database/seed project or scripts and document migrations in this file.

-- End of PROJECT_CONTEXT.md
