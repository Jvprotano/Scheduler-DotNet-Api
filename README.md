
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
