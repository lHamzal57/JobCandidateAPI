# JobCandidate

JobCandidate is an ASP.NET Core application that demonstrates the use of Clean Architecture, AutoMapper, Serilog, and the Unit of Work pattern. The application allows for managing job candidate information through a REST API.

## Table of Contents

1. [Getting Started](#getting-started)
2. [Project Structure](#project-structure)
3. [Setup and Configuration](#setup-and-configuration)
4. [Running the Application](#running-the-application)
5. [Running Tests](#running-tests)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

    ```sh
    git clone https://github.com/your-repo/JobCandidate.git
    cd JobCandidate
    ```

2. Restore the NuGet packages:

    ```sh
    dotnet restore
    ```

## Project Structure

JobCandidate.sln
│
├───JobCandidate.Domain
│ ├───Entities
│ ├───Interfaces
│ └───Common
│
├───JobCandidate.Application
│ ├───Interfaces
│ ├───Services
│
├───JobCandidate.Infrastructure
│ ├───Data
│ ├───Repositories
│
├───JobCandidate.API
│ ├───Controllers
│ ├───Auto
│ ├───Program.cs
│ ├───Startup.cs
│ └───appsettings.json
│
├───JobCandidate.Tests
│ ├───Services
│ ├───Controllers


## Setup and Configuration

### Database Configuration

1. Update the connection string in `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=JobCandidateDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```

2. Add the database context configuration in `Program.cs`:

    ```csharp
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Other configurations
    ```


### Serilog Configuration

1. Install Serilog packages:

    ```sh
    dotnet add package Serilog.AspNetCore
    dotnet add package Serilog.Sinks.Console
    dotnet add package Serilog.Sinks.File
    ```

2. Configure Serilog in `Program.cs`:

    ```csharp
    using Serilog;

    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    builder.Host.UseSerilog();

    // Other configurations
    ```

3. Add Serilog settings in `appsettings.json`:

    ```json
    {
      "Serilog": {
        "MinimumLevel": {
          "Default": "Information",
          "Override": {
            "Microsoft": "Warning",
            "System": "Warning"
          }
        },
        "WriteTo": [
          {
            "Name": "Console"
          },
          {
            "Name": "File",
            "Args": {
              "path": "logs/log-.txt",
              "rollingInterval": "Day"
            }
          }
        ],
        "Enrich": [ "FromLogContext" ],
        "Properties": {
          "Application": "JobCandidate"
        }
      }
    }
    ```

## Running the Application

1. Apply database migrations:

    ```sh
    dotnet ef migrations add InitialCreate -p JobCandidate.Infrastructure -s JobCandidate.API
    dotnet ef database update -p JobCandidate.Infrastructure -s JobCandidate.API
    ```

2. Run the application:

    ```sh
    dotnet run --project JobCandidate.API
    ```

## Running Tests

1. Navigate to the test project directory:

    ```sh
    cd JobCandidate.UnitTest
    ```

2. Run the tests:

    ```sh
    dotnet test
    ```
The Result of tests:

```A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     5, Skipped:     0, Total:     5, Duration: 1 s - JobCandidate.UnitTest.dll (net8.0)```
